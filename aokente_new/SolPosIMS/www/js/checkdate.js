function checkdate(time1, time2) {
    //得到日期值并转化成日期格式，replace(/\-/g, "\/")是根据验证表达式把日期转化成长日期格式，这样

    //再进行判断就好判断了
    if (document.getElementById(time1).value != "" && document.getElementById(time1).value != "" && document.getElementById(time2).value != null && document.getElementById(time2).value != null) {

        var sDate = new Date(document.getElementById(time1).value.replace(/\-/g, "\/"));
        var eDate = new Date(document.getElementById(time2).value.replace(/\-/g, "\/"));
        if (sDate > eDate) {
            alert("结束日期不能小于开始日期");
            return false;
        }
        return true;
    }
    else {
        return true;
    }
}