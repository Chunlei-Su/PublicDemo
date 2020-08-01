

select top 8 CommodityBrowse,CommodityName, CommodityPic, CommodityPrice from CommodityInfo c inner join SellerInfo s on c.SellerNumber=s.SellerNumber where ShopName='ÖÐ¹úÀîÄþÆì½¢µê' order by CommodityBrowse desc

declare @shopname nvarchar(20)
set @shopname='ÎÄÒÕÄÐ'
select CommodityName, CommodityPic, CommodityPrice
from(	select CommodityName, CommodityPic, CommodityPrice ,row_number() over(order by CommodityID) rn 
		from CommodityInfo c inner join SellerInfo s on c.SellerNumber=s.SellerNumber where ShopName =@shopname and CommodityName like '%ÏÄ%' ) 
t where rn between 1 and 8 order by CommodityName


select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName from(select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName, row_number() over(order by CommodityID) rn from CommodityInfo inner join SellerInfo on CommodityInfo.SellerNumber = SellerInfo.SellerNumber where CommodityName like '%ÏÄ%' and CommodityPrice between 0 and 100 and CommodityBrowse between 500 and 1000 ) t where rn between 1 and 8 order by CommodityNumber  desc


declare @commoditySearch nvarchar(20)
set @commoditySearch='%ÏÄ%'
select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName from(select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName,CommodityBrowse, row_number() 
	over(order by CommodityID) rn from SellerInfo s inner join CommodityInfo c on c.SellerNumber = s.SellerNumber inner join CommodityClassInfo i on  c.CommodityClass=i.ClassID
	where CommodityName like @commoditySearch ) t where rn between 1 and 8 order by CommodityNumber  desc

select COUNT(CommodityNumber) from CommodityInfo where CommodityName like '%%' and CommodityPrice between 0 and 100 


select top 8 CommodityName, CommodityPic, CommodityPrice from CommodityInfo c inner join SellerInfo s on c.SellerNumber=s.SellerNumber where ShopName=@sellername order by CommodityBrowse desc 
select count(CommodityNumber) from CommodityInfo inner join SellerInfo on CommodityInfo.SellerNumber=SellerInfo.SellerNumber where ShopName=@shopname and  CommodityName like @keyword


select count(CommodityNumber) from CommodityInfo inner join SellerInfo on CommodityInfo.SellerNumber=SellerInfo.SellerNumber where ShopName=@shopname and  CommodityName like ''


select  CustomerNumber, FeedbackContent from(select  CustomerNumber, FeedbackContent ,row_number() 
	over(order by FeedbackID ) rn from CommodityFeedback where ShopName=@shopname and CommodityNumber=@commoditynumber ) t where rn between 1 and 8 


insert into DealInfo(CustomerNumber, CommodityNumber, CommoditySize, CommodityColor, SellerNumber, DealCount, NowStats, OrdersTime, OneMoeny) values()


select count(DealID) from DealInfo where CustomerNumber and CommodityNumber and SellerNumber

update CommodityInfo set CommodityInventory-=2 where CommodityNumber= and SellerNumber=

select CustomerAddress from CustomerInfo where CustomerNumber=

select  CommodityName, CommodityPic,d.CommoditySize,d.CommodityColor, DealCount,CommodityInventory from DealInfo d inner join CommodityInfo c on d.CommodityNumber =c.CommodityNumber where CustomerNumber= and d.SellerNumber= and d.CommodityNumber=

select count(*) from CommodityInfo group by SellerNumber

update DealInfo set NowStats= ,OrdersTime= ,CustomerAddress= where 

select CommodityName, DealCount,CommodityInventory,CommodityPic,OneMoeny, d.CommoditySize,d.CommodityColor,ShopName from CommodityInfo c inner join DealInfo d on c.CommodityNumber=d.CommodityNumber inner join SellerInfo s on d.SellerNumber=s.SellerNumber 

select CustomerNumber, CustomerName, CustomerHead, CustomerTel, CustomerAddress,SellerNumber from CustomerInfo 

update CustomerInfo set CustomerHead=  ,CustomerAddress= ,CustomerName= CustomerTel

select COUNT(CustomerNumber) from DealInfo where CustomerNumber= and NowStats=

select ShopName from CustomerCollection where CustomerNumber=


CustomerNumber, ShopName

update CommodityInfo set CommodityBrowse+=1 where CommodityNumber='S202000001'


select SellerID, SellerNumber, ShopName, ShopAddress, SellerLogo, SellerPic, ExclusiveWeb from SellerInfo where SellerNumber in (select sellernumber from CustomerInfo where CustomerNumber='C000000001')

update SellerInfo set ShopName= ,ShopAddress, SellerLogo, SellerPic,

select COUNT(AdminAccount) from AdminInfo where AdminAccount= and AdminPwd=


select SUM(DealCount*OneMoeny) from DealInfo where DealKey='f3f9ec88-ebc6-43d3-9940-fe22c3e02b91'

update DealInfo set NowStats=,PayTime=  where DealKey=@dealkey

select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName,SellerNumber from 
(select CommodityNumber, CommodityName, CommodityClass, CommodityPic, CommodityPrice, ShopName,SellerInfo.SellerNumber, CommodityBrowse,row_number() over(order by CommodityID) rn from CommodityInfo inner join SellerInfo on CommodityInfo.SellerNumber = SellerInfo.SellerNumber 
where CommodityStats=@CommodityStats and CommodityName like @commoditySearch {filtersql}) t where rn between {pagemin} and {pagemax} {orderstring}

insert into CommodityInfo(CommodityNumber, CommodityName, CommodityClass, CommoditySize, CommodityColor, CommodityPic, CommodityInventory, CommodityIntroduce, CommodityPrice, SellerNumber, CommodityBrowse, CommodiryAddTime) 
values(@CommodityNumber, @CommodityName, @CommodityClass, @CommoditySize,@CommodityColor, @CommodityPic, @CommodityInventory, @CommodityIntroduce, @CommodityPrice, @SellerNumber, @CommodityBrowse, @CommodiryAddTime)


select top 1 CommodityNumber  from CommodityInfo  order by CommodityNumber desc