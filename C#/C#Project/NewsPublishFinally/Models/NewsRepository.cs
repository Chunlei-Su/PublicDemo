using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace NewsPublishFinally.Models
{
    /// <summary>
    /// 对新闻数据的读取
    /// </summary>
    public class NewsRepository
    {
        private SqlHelper _sqlHelper;

        public NewsRepository(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        /// <summary>
        /// 获取全部的新闻数据
        /// </summary>
        public List<object> GetAllNews(int pages = 1)
        {
            int result = GetNewsCount();
            int count = (result % 12) == 0 ? result / 12 : result / 12 + 1;
            if (pages < 1)
            {
                pages = 1;
            }
            if (pages > count)
            {
                pages = count;
            }

            //save news data
            List<Hashtable> hashtables = new List<Hashtable>();
            SqlDataReader reader = _sqlHelper.ExecuteReader("select NewsTitle,NewsClass,NewsContent,NewsPublishTime from newsinfo");
            if (reader.HasRows)
            {
                Hashtable hashtable = null;
                for (int i = 12; i < pages * 12; i++)
                {
                    reader.Read();
                }
                for (int j = 0; j < 12; j++)
                {
                    if (!reader.Read())
                    {
                        break;
                    }
                    hashtable = new Hashtable();
                    hashtable.Add("NewsTitle", reader.GetString(0));
                    hashtable.Add("NewsContent", reader.GetString(2));
                    hashtable.Add("NewsPublishTime", reader.GetDateTime(3).ToString("yyyy-MM-dd"));

                    hashtables.Add(hashtable);
                }
            }

            List<object> list = new List<object>();
            list.Add(hashtables);


            //计算要显示的页码
            int[] pagearray = new int[7];
            if (count - pages >= 5)
            {
                pagearray[0] = pages - 1;
                pagearray[1] = pages + 1;
                pagearray[2] = pages;
                pagearray[3] = pages + 1;
                pagearray[4] = pages + 2;
                pagearray[5] = pages + 3;
                pagearray[6] = count;
            }
            else
            {
                pagearray[0] = pages - 1;
                pagearray[1] = pages + 1;
                pagearray[2] = count - 4;
                pagearray[3] = count - 3;
                pagearray[4] = count - 2;
                pagearray[5] = count - 1;
                pagearray[6] = count;
            }

            //save pagesum
            list.Add(pagearray);

            //save current page of show
            list.Add(pages);
            return list;
        }

        /// <summary>
        /// 获取数据总数
        /// </summary>
        public int GetNewsCount()
        {
            return (int)_sqlHelper.ExecuteScalar("select count(NewsTitle) from newsinfo");
        }

        //获取一个类的新闻
        public List<Hashtable> GetClassNews(string cname)
        {
            List<Hashtable> hashtables = new List<Hashtable>();
            SqlDataReader reader = _sqlHelper.ExecuteReader("select NewsTitle,NewsClass, NewsContent, NewsPublishTime from NewsInfo where NewsClass=@cname", new SqlParameter("@cname", cname));
            if (reader.HasRows)
            {
                Hashtable hashtable = null;
                while (reader.Read())
                {
                    hashtable = new Hashtable();
                    hashtable.Add("NewsTitle", reader.GetString(0));
                    hashtable.Add("NewsClass", reader.GetString(1));
                    hashtable.Add("NewsContent", reader.GetString(2));
                    hashtable.Add("NewsPublishTime", reader.GetDateTime(3).ToString("yyyy-MM-dd"));

                    hashtables.Add(hashtable);
                }
            }
            return hashtables;
        }

        //获取新闻详情及评论
        public List<object> GetNewsContentAndComment(string title)
        {
            List<object> hashtables = new List<object>();
            SqlDataReader reader = _sqlHelper.ExecuteReader("select NewsTitle,NewsClass, NewsContent, NewsPublishTime from NewsInfo where NewsTitle=@title", new SqlParameter("@title", title));
            if (reader.HasRows)
            {
                Hashtable hashtable = null;
                if (reader.Read())
                {
                    hashtable = new Hashtable();
                    hashtable.Add("NewsTitle", reader.GetString(0));
                    hashtable.Add("NewsClass", reader.GetString(1));
                    hashtable.Add("NewsContent", reader.GetString(2));
                    hashtable.Add("NewsPublishTime", reader.GetDateTime(3).ToString("yyyy-MM-dd"));

                    hashtables.Add(hashtable);
                    //获取此项新闻的评论
                    hashtables.Add(GetNewsComment(reader.GetString(0), reader.GetString(1), reader.GetDateTime(3).ToString("yyyy-MM-dd")));
                }
            }

            return hashtables;
        }

        //获取评论
        public List<Hashtable> GetNewsComment(string title, string classname, string pubtime)
        {
            List<Hashtable> hashtables = new List<Hashtable>();
            SqlDataReader reader = _sqlHelper.ExecuteReader("select NewsFeedback, FeedbackTime  from NewsContentFeedback where NewsTitle = @title and NewsClass =@class and NewsPublishTime = @time", new SqlParameter[] { new SqlParameter("@title", title), new SqlParameter("@class", classname), new SqlParameter("@time", pubtime) });
            if (reader.HasRows)
            {
                Hashtable hashtable = null;
                while (reader.Read())
                {
                    hashtable = new Hashtable();
                    hashtable.Add("NewsFeedback", reader.GetString(0));
                    hashtable.Add("FeedbackTime", reader.GetDateTime(1).ToString("yyyy-MM-dd"));

                    hashtables.Add(hashtable);
                }
            }
            return hashtables;
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        public void AddComment(NewsInfo news)
        {
            string sql = "insert into NewsContentFeedback( NewsTitle, NewsClass, NewsPublishTime, NewsFeedback, FeedbackTime) values(@title,@class,@pubtime,@feed,@feedtime)";
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@title",news.title),
                new SqlParameter("@class",news.classname),
                new SqlParameter("@pubtime",news.time),
                new SqlParameter("@feed",news.comment),
                new SqlParameter("@feedtime",DateTime.Now)
            };

            _sqlHelper.ExecuteNonQuery(sql,parameters);
        }

    }
}
