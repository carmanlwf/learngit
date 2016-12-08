// JScript 文件

//查看人员基本信息
function doSeeInfo(Userid)
{
    openBrWindow('MemberOperation.aspx?statu=readonly&getcode=' + Userid ,'SeeMemberInfoInfo','405','400');
}
function doSeeInfo2(RankId)
{
    openBrWindow('MemberLevelOper.aspx?statu=readonly&getcode=' + RankId ,'SeeMemberInfo','355','350');
}