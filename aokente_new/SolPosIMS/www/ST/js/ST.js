// JScript 文件

//查看人员基本信息
function doSeeInfo(id)
{
    openBrWindow('SiteOperation.aspx?statu=readonly&getcode=' + id ,'SeeSiteInfo','405','350');
}
function doSeeInfo2(areacode)
{
    openBrWindow('AreaOperation.aspx?statu=readonly&getcode=' + areacode ,'SeeAreaInfo','405','260');
}