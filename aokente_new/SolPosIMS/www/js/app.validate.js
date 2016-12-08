


/*
*******总体说明：

在页面上加入：
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

控件上需要添加的属性：
vmode：是否为空的验证。
vtype：验证控件使用的规则。
vdisp：错误提示中的控件描述。
vtextarea：是否验证字符串的长度。
maxlength：字符串的最大长度。
voperate：比较验证使用的验证规则，以及使用自定义正则表达式
passvalue：范围值
extendname：特殊字符串
max：范围上限
min：范围下限
to：被比较的控件名
regexp：自定义正则表达式

属性规则：
控件上不设置vmode属性，即表示控件可为空；
控件上不设置vdisp属性，则错误提示中的控件描述信息为控件的id。
控件上不设置vtype属性，即表示不对控件进行规则验证；
控件上不设置vtextarea属性，即表示不对控件进行字符串长度的验证；
vtextarea和maxlength必须成对使用；

vmode的值：
not null：　不能为空

vtype的值：
chinese：　中文
english：　英文字母
number：　阿拉伯数字
integer：　整数
float：　浮点数
double：　实数
string：　不含特殊符合的字符串
int：　正整数
minusint：　负整数，比如　-123
date：　日期型，比如 2004-08-12
time：　时间型，比如　08:37:29
datehm：　日期时分型，比如 2004-08-12 12:25
datetime：　日期时间型，比如　2004-08-12 08:37:29
year：　年代格式，比如 2005
month：　月份格式，比如 08
day：　日子格式，比如 14
postcode：　邮编，比如 100001
email：　电子邮件格式，比如 msm@hotmail.com
phone：　电话号码格式，比如010-67891234
mobiletel：　手机号码格式，比如13867891234
ip：　机器ip地址格式，比如 172.22.169.11
idcard：　身份证号码，比如15位或者18位数字
tabledefine：　abc_defgf
Let terStr：　纯字母字符串
NumAndStr：　数字和字母字符串
NumStr：　纯数字组成的字符串

vtextarea的值：
yes：　需要验证长度

voperate的值：
repeat：验证两控件内容是否一致
rangeint：验证控件的值范围(int)
    max：范围上限
    min：范围下限
rangestr：验证控件的值范围(string)
    max：范围上限
    min：范围下限
largestr：比较控件的值，目标控件的值必须小于当前控件(string)
largeequalstr：比较控件的值，目标控件的值必须小于或者等于当前控件(string)
largeint：比较控件的值，目标控件的值必须小于当前控件(int)
largeintvalue：比较控件的值，目标控件的值必须小于当前控件一定的值(int)
    passvalue：范围值
largeequalint：比较控件的值，目标控件的值必须小于或者等于当前控件(int)
extend：控件值是否包含特定字符串
    extendname：特殊字符串
custom：自定义正则表达式
    regexp：自定义正则表达式
blank： 验证两控件状态是否一致（必须同时为空或者同时有值）
largemonth：比较控件的值，目标控件的值必须大于当前控件一个月
smallmonth：比较控件的值，目标控件的值必须小于当前控件一个月
largemoremonth:比较控件的值，目标控件的值必须大于当前控件n个月(添加属性moremonth)
*/

/*

********验证方式一：
采用Form验证

触发验证的按钮上需要添加的事件
HtmlControl : onclick = "if (函数名(参数...))"
WebContrl : OnClientClick="return 函数名(参数...);"

验证的函数包括：

doSingleMessageBoxValidate( vform )：　以MessageBox方式进行错误提示，同时只显示第一个
doAllMessageBoxValidate( vform )：　以MessageBox方式进行错误提示，同时显示所有
doSummaryValidate( vform , SummaryControl )：　以Summary方式进行错误提示，同时显示所有
doFormValidate( vform , isMessageBox , isSummary , isShowAll , SummaryControl )

参数含义：
vform：　需要验证的Form名
isMessageBox：　错误提示是否为MessageBox方式
isSummary：　错误提示是否为Summary方式
isShowAll：　是否一次性显示所有错误
SummaryControl：　显示错误信息的控件

注：isSummary和SummaryControl必须成对使用


用法举例：
需要验证的控件：<input id="name" type="text" runat="server" vmode="not null" vtype="number" vdisp="姓名"/>
触发验证的HtmlControl：<input type="button" value="submit" onclick="if (doAllMessageBoxValidate(form1))" onserverclick="tt_onserverclick" runat="server" id="Button1" />
触发验证的WebContrl：<asp:Button ID="btn" Text="btn" OnClientClick="return doAllMessageBoxValidate(form1);" runat="server" OnClick="btn_Click" />
*/

/*
********验证方式二：
采用 asp.net CustomValidator验证控件方式验证

CustomValidator验证控件属性说明：
ValidateEmptyText：　当控件值为空的时候是否进行验证
Display：　错误信息占位方式
ClientValidationFunction：　验证函数（注：用本ＪＳ，验证函数为：doAspNetValidate）

验证的函数包括：
doAspNetValidate(oSrc, args)

用法举例：
需要验证的控件：<input id="name" type="text" runat="server" vmode="not null" vtype="number" vdisp="姓名"/>
验证控件：<asp:CustomValidator ValidateEmptyText="true" ID="nameCustomValidator1" Display="Static" runat="server" ClientValidationFunction="doAspNetValidate" ErrorMessage="CustomValidator" ControlToValidate="name"></asp:CustomValidator>

*/





/*

下面为具体实现

*/

//普通Form方式验证
//以MessageBox方式进行错误提示，同时只显示第一个
function doSingleMessageBoxValidate( vform )
{
    if (doFormValidate(vform , true , null  , null , null))
        return true;
    else
        return false;     
} 

//普通Form方式验证
//以MessageBox方式进行错误提示，同时显示所有
function doAllMessageBoxValidate( vform )
{
    if (doFormValidate(vform , true , null  , true , null))
        return true;
    else
        return false; 
} 

//普通Form方式验证
//以Summary方式进行错误提示，同时显示所有
//SummaryControl　为显示所有错误信息的控件
function doSummaryValidate( vform , SummaryControl )
{
    if (doFormValidate(vform , null , true  , true , SummaryControl))
        return true;
    else
        return false; 
} 


var validrule                  = new Object();
validrule.chinese              = /^([\u0391-\uFFE5|\s*]+$)?$/; 
validrule.english              = /^([a-zA-Z|\s*]+)?$/; 
validrule.number               = /^(\d*)?$/; 
validrule.integer              = /^([-\+]?\d{1,9})?$/;
validrule.float                = /^((([-\+]?\d+)(\.\d+))|(\.\d+)|(\d*))?$/;
validrule.double               = /^((([-\+]?\d+)(\.\d+))|(\.\d+)|(\d*))?$/;
validrule.string               = /^([^'<>"]+)?$/;
validrule.int                  = /^(\d{1,9})?$/; 
validrule.minusint             = /^(\-([1-9])(\d*))?$/;                  
validrule.date                 = /^((([1-9]\d{3})|([1-9]\d{1}))-(0[1-9]|1[0-2])-(0[1-9]|[1-2]\d|3[0-1]))?$/;  
validrule.time                 = /^((0[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9]))?$/; 
validrule.datetime             = /^((([1-9]\d{3})|([1-9]\d{1}))-(0[1-9]|1[0-2])-(0[1-9]|[1-2]\d|3[0-1]) (0[0-9]|1[0-9]|2[0-4]):([0-5][0-9]):([0-5][0-9]))?$/; 
validrule.datehm               = /^((([1-9]\d{3})|([1-9]\d{1}))-(0[1-9]|1[0-2])-(0[1-9]|[1-2]\d|3[0-1]) (0[0-9]|1[0-9]|2[0-4]):([0-5][0-9]))?$/;     
validrule.year                 = /^(\d{4})?$/; 
validrule.month                = /^([1-9]|0[1-9]|1[0-2])?$/;
validrule.day                  = /^([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])?$/;
validrule.postcode             = /^(\d{6})?$/;           
validrule.email                = /^(.+\@.+\..+)?$/;
validrule.phone                = /^(\(\d{3}\))?(\(?(\d{3}|\d{4}|\d{5})\)?(-?)(\d+))?((-?)(\d+))?$/; 
validrule.mobiletel            = /^(01(3|5|8)(\d{9})|1(3|5|8)(\d{9}))?$/; 
validrule.ip                   = /^(([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-5][0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-5][0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-5][0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-5][0-5]))?$/;  
validrule.idcard               = /^(\d{15}|\d{18}|\d{17}X|\d{17}x)?$/; 

validrule.tabledefine          = /^(([A-Za-z])([A-Za-z0-9|_]){1,18})?$/; 

 
validrule.NumAndStr            = /^([0-9a-zA-Z]+)?$/;  
validrule.LetterStr            = /^([a-zA-Z]+)?$/;
validrule.NumStr               = /^(\d*)?$/; 
 
//普通Form方式验证
function doFormValidate( vform , isMessageBox , isSummary , isShowAll , SummaryControl ) 
{
	var elems = vform.elements;
	var frmLen = elems.length;
	var thePat = "";
	var strFormatInfo = "";
	var errormessage = new Array();
	var j = 0;
	
	//对于每一个FROM元素
	for(var i=0;i<frmLen;i++) 
	{
		var _elem = elems[i];
		var elemdescrip = ValidateDescrip( _elem.vdisp , _elem);
		errormessage[j] = "";
		
		//对每一个FROM元素进行验证      
        errormessage[j] = errormessage[j] + CheckElem(_elem , elemdescrip);
	    
	    //显示单个错误消息  	
	    if (errormessage[j] != "")
	      	{
	      	    if ( isShowAll != true || isShowAll == null )
	      	    {
	      	        if ( isMessageBox == true )
	      	        {
	      	            alert(errormessage[j]);
	      	            _elem.focus();
	      	            return false;
	      	        }
	      	        
	      	        if ( isSummary == true && SummaryControl != null)
	      	        {
	      	            var ctr = document.getElementById(SummaryControl);
	      	            ctr.value = errormessage[j];
	      	        }
	      	        
	      	    }
	      	    j = j + 1;
	      	} 
	      	
	} 
	
	//显示全部错误消息
	var allerrormessage = "" ;
	if ( errormessage.length == 1 &&  errormessage[0] == "")
	{
	    return true;
	} 
	else
	{
	    for ( var k = 0 ; k < errormessage.length ; k ++)
	    {
	        if ( errormessage[k].toString() != "" && errormessage[k].toString() != "undefined")
	        {
	            allerrormessage = allerrormessage + "·" + errormessage[k] + "\r\n";
	        }
        }
	        if ( isMessageBox == true )
            {
                alert(allerrormessage);
            }
            if ( isSummary == true && SummaryControl != null)
            {
                  SummaryControl.value = allerrormessage;     
            }
            return false;
	}
}



//asp.net CustomValidator验证控件方式验证
function doAspNetValidate(oSrc, args)
{
  var b = document.getElementById(oSrc.controltovalidate);
  var elemdescrip = ValidateDescrip( b.vdisp , b);
  var message = "";
  
  //为空检查
  message = message + CheckElem(b , elemdescrip);
 
  if( message != "") 
    {	      	 
        alert(message);
        b.focus();
        args.IsValid = false;
        return ;
    }
}

function CheckElem(_elem , elemdescrip)
{
    var elemdescrip = ValidateDescrip( _elem.vdisp , _elem);
		errormessage = "";
		
		//为空检查                
        errormessage = ValidateNull(_elem.value , _elem.vmode , elemdescrip);	 
        
        //类型检查                  
		if(_elem.vtype != null) 
		{
			errormessage = errormessage + ValidateType( _elem.vtype , _elem.value , elemdescrip); 		      	      	
	    }
	    
	    //长度检查
	    errormessage = errormessage + ValidateLenth( stringLength(_elem.value) , _elem.maxlength , _elem.vtextarea ,elemdescrip);
	    
	    errormessage = errormessage + ValidateCompare(_elem , elemdescrip);
	    
	    return errormessage;
}

function stringLength(str)
{
    if(typeof(str) != 'string' || str == null) return 0;
	var len = str.replace(/[\u00ff-\uffff]/g,"aa").length;
	return len;
}

function ValidateDescrip(vdisp , elem)
{
    var elemdescrip = "";
    if ( vdisp == null || vdisp == "")
		{
		   if(elem.parentElement.tagName == "TD" && elem.parentElement.previousSibling != null)
            elemdescrip = elem.parentElement.previousSibling.innerHTML;
		   else 
		    elemdescrip = elem.id;
		}
    else
		{
		    elemdescrip = elem.vdisp;
		}
    return elemdescrip;
}

//长度验证
function validatelenth(ivaluelength , imaxlength)
{
    if(ivaluelength>=imaxlength)
    {
        return false;
    }    
    else
    {
        return true;
    }
}

function ValidateLenth(ivaluelength , imaxlength , vtextarea , elemdescrip )
{
    var message = "";
    if(vtextarea=="yes")         
    {       	      	    
        if (!(validatelenth(ivaluelength , imaxlength)))
        {
            message = elemdescrip + "输入的值长度太长超过了" + imaxlength + "个字符";
        }
    }
    return message;
}

//为空验证
function validatenull( vvalue )
{
    if(vvalue.length == 0) 
    {
        return false;
    }
    else
    {
	    return true;
    }
}

function ValidateNull( vvalue ,vmode ,elemdescrip)
{
    var errormessage = "";
    if(vmode != null && vmode == "not null") 
    {
        if (!(validatenull(vvalue))) 
        {
            errormessage = elemdescrip + "不能为空!";
        }
    }
    return errormessage;	
}

function ValidateCompare(_elem , elemdescrip)
{
    var errormessage = "";
    var tocontrol = document.getElementById(_elem.to);
    //验证两控件内容是否一致
    if(_elem.voperate=="repeat")         
	{       	      	  
	    if(_elem.value != tocontrol.value)
	        {
	      	    _elem.focus();
	      	    errormessage = elemdescrip + "　输入内容与　" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "　不一致！";
	      		return errormessage;
	      	}
	}
	
	//验证两控件状态是否一致（同时为空或者同时有值）
	if (_elem.voperate == "blank")
	{
	    if (!validatenull(_elem.value))
	    {
	        if ( validatenull(tocontrol.value))
	        {
	            _elem.focus();
	      	    errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "　必须为空！";
	      		return errormessage;
	        }
	    }
	    else
	    {
	        if ( !validatenull(tocontrol.value))
	        {
	            _elem.focus();
	      	    errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "　不能为空！";
	      		return errormessage;
	        }
	    }
	}
	
	//如checkbox被勾选，则比较控件不能为空
	if (_elem.voperate == "checked")
	{
	    if (!_elem.checked)
	    {
	        if ( validatenull(tocontrol.value))
	        {
	            _elem.focus();
	      	    errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "　必须为空！";
	      		return errormessage;
	        }
	    }
	    else
	    {
	        if ( !validatenull(tocontrol.value))
	        {
	            _elem.focus();
	      	    errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "　不能为空！";
	      		return errormessage;
	        }
	    }
	}
	
	//验证控件的值范围(int)
	if(_elem.voperate=="rangeint")         
	      	{        	      	      	  
	      	   if(parseInt(_elem.value) > parseInt(_elem.max) || parseInt(_elem.value) < parseInt(_elem.min))
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "　超出　" + _elem.min + " -- " + _elem.max + "　的范围！";
	      		     return errormessage;
	      	   }
	      	}
	
	//验证控件的值范围(string)      	
	if(_elem.voperate=="rangestr")         
	      	{  	      		      	      	      	  
	      	   if(_elem.value > _elem.max || _elem.value < _elem.min)
	      	   {
	      	        _elem.focus();
	      	        errormessage = elemdescrip + "　超出　" + _elem.min + " -- " + _elem.max + "　的范围！";
	      		    return errormessage;
	      	   }
	      	} 
	
	//比较控件的值，目标控件的值必须小于当前控件(string)     	
    if(_elem.voperate=="largestr")         
	      	{       	      	  
	      	   if(_elem.value <= document.getElementById(_elem.to).value)
	      	   {
                    _elem.focus();
                    errormessage = elemdescrip + "　必须大于　" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "　的值！";
	      		    return errormessage;
	      	   }
	      	}
	      	
    //比较控件的值，目标控件的值必须小于或者等于当前控件(string)
    if(_elem.voperate=="largeequalstr")         
	      	{       	      	  
	      	   if(_elem.value < document.getElementById(_elem.to).value)
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "　必须大于或者等于　" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "　的值！";
	      		     return errormessage;
	      	   }
	      	}
	 
	 //比较控件的值，目标控件的值必须小于当前控件(int)     	
	 if(_elem.voperate=="largeint")         
	      	{       	      	  
	      	   if(parseInt(_elem.value) <= parseInt(document.getElementById(_elem.to).value))
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "　必须大于　" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "　的值！";
	      		     return errormessage;
	      	   }
	      	}
	 
	 //比较控件的值，目标控件的值必须小于当前控件一定的值(int)     	    	
	 if(_elem.voperate=="largeintvalue")         
	      	{       	      	  
	      	   if((parseInt(_elem.value) + parseInt(_elem.passvalue)) <= parseInt(tocontrol.value))
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "　的值必须大于　" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "　的值减去　" + _elem.passvalue ;
	      		     return errormessage;
	      	   }
	      	} 
	 
	 //比较控件的值，目标控件的值必须大于当前控件一个月 
	 if(_elem.voperate=="largemonth")         
	      	{
	      	    var month = parseInt(_elem.value.substring(5,7));
	      	    var year = _elem.value.substring(0,4);
	      	    var stringdate = "";
	      	    month = month + 1;
	      	    if ( month > 12 )
	      	        {
	      	            month = 1;
	      	            year = parseInt(year) + 1 ;
	      	        }
	      	    if ( month.toString().length == 1)
	      	        stringdate = year + "-0" + month + "-" + _elem.value.substring(8,10) ;
	      	    else
	      	        stringdate = year + "-" + month + "-" + _elem.value.substring(8,10) ;          	      	  
	      	   if( stringdate > tocontrol.value )
	      	   {
	      	         _elem.focus();
	      	         errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "　必须大于　" + elemdescrip + "　一个月！";
	      		     return errormessage;
	      	   }
	      	}	
	      	
	 //比较控件的值，目标控件的值必须大于当前控件一个月 
	 if(_elem.voperate=="largemoremonth")         
	      	{
	      	    var month = parseInt(_elem.value.substring(5,7));
	      	    var year = _elem.value.substring(0,4);
	      	    var stringdate = "";
	      	    var moremonth = _elem.moremonth;
	      	    month = month + moremonth;
	      	    if ( month > 12 )
	      	        {
	      	            month = month - 12;
	      	            year = parseInt(year) + 1 ;
	      	        }
	      	    if ( month.toString().length == 1)
	      	        stringdate = year + "-0" + month + "-" + _elem.value.substring(8,10) ;
	      	    else
	      	        stringdate = year + "-" + month + "-" + _elem.value.substring(8,10) ;          	      	  
	      	   if( stringdate > tocontrol.value )
	      	   {
	      	         _elem.focus();
	      	         errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "　必须大于　" + elemdescrip + moremonth + "个月！";
	      		     return errormessage;
	      	   }
	      	}      	    	 
	
	//比较控件的值，目标控件的值必须大于当前控件一个月
	if(_elem.voperate=="smallmonth")         
	      	{
	      	    var month = parseInt(_elem.value.substring(5,7));
	      	    var year = _elem.value.substring(0,4);
	      	    var stringdate = "";
	      	    month = month + 1;
	      	    if ( month > 12 )
	      	        {
	      	            month = 1;
	      	            year = parseInt(year) + 1 ;
	      	        }
	      	    if ( month.toString().length == 1)
	      	        stringdate = year + "-0" + month + "-" + _elem.value.substring(8,10) ;
	      	    else
	      	        stringdate = year + "-" + month + "-" + _elem.value.substring(8,10) ;          	      	  
	      	   if( stringdate < tocontrol.value )
	      	   {
	      	         _elem.focus();
	      	         errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "　必须小于　" + elemdescrip + "　一个月！";
	      		     return errormessage;
	      	   }
	      	}
	
	//比较控件的值，目标控件的值必须小于或者等于当前控件(int)          	
    if(_elem.voperate=="largeequalint")         
	      	{       	      	  
	      	   if(parseInt(_elem.value) < parseInt(document.getElementById(_elem.to).value))
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "　必须大于或者等于　" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "　的值！";
	      		     return errormessage;
	      	   }
	      	}   
	      	
    //控件值是否包含特定字符串
    if(_elem.voperate=="extend")         
	      	{       	      	    
	      	   if((_elem.value).lastIndexOf(_elem.extendname)< 0)
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "　必须包含字符：　" + _elem.extendname;
	      		     return errormessage;
	      	   }
	      	} 
	
	//自定义正则表达式      	
    if(_elem.voperate=="custom")         
	      	{
	      	    if ( _elem.value != null && _elem.value != "")  
	      	    {     	      	    
	      	     if(!RegExp(_elem.regexp,"g").test(_elem.value))
	      	     {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "　不符合正则表达式：　" + _elem.extendname + "　的要求！　";
	          		 return errormessage;
	      	     }
	      	   }
	      	}
    return errormessage; 
}

//类型验证
function ValidateType(vtype , vvalue  , elemdescrip)
{
    var thePat;
    var strFormatInfo;
    var typelist = new Array();
	      	if(vtype=="chinese")
	      	{       
	      	   thePat = validrule.chinese;
	      	   strFormatInfo = "中文";
	      	}
	      	if(vtype=="english")
	      	{       
	      	   thePat = validrule.english;
	      	   strFormatInfo = "英文字母";
	      	}
	      	if(vtype=="number")
	      	{       
	      	   thePat = validrule.number;
	      	   strFormatInfo = "阿拉伯数字";
	      	}
	      	if(vtype=="integer")
	      	{       
	      	   thePat = validrule.integer;
	      	   strFormatInfo = "整数";
	      	}
	      	if(vtype=="float")
	      	{       
	      	   thePat = validrule.float;
	      	   strFormatInfo = "浮点数";
	      	}
	      	if(vtype=="double")
	      	{       
	      	   thePat = validrule.double;
	      	   strFormatInfo = "实数";
	      	}
	      	if(vtype=="string")
	      	{       
	      	   thePat = validrule.string;
	      	   strFormatInfo = "不含特殊符合的字符串";
	      	}
	      	if(vtype=="int")         
	      	{       
	      	   thePat = validrule.int;
	      	   strFormatInfo = "正整数";
	      	}
	      	if(vtype=="minusint")         
	      	{       
	      	   thePat = validrule.minusint;
	      	   strFormatInfo = "负整数，比如-123";
	      	}
	      	if(vtype=="date")         
                {       
	      	   thePat = validrule.date;
	      	   strFormatInfo = "日期型，比如 2004-08-12";
	      	}
	      	if(vtype=="time")         
	      	{       
	      	   thePat = validrule.time;
	      	   strFormatInfo = "时间型，比如08:37:29";
	      	}
	      	if(vtype=="datehm")         
                {       
	      	   thePat = validrule.datehm;
	      	   strFormatInfo = "日期时分型，比如 2004-08-12 12:25";
	      	}	      	 
	      	if(vtype=="datetime")         
	      	{       
	      	   thePat = validrule.datetime;
	      	   strFormatInfo = "日期时间型，比如2004-08-12 08:37:29";
	      	}
            if(vtype=="year")         
	      	{       
	      	   thePat = validrule.year;
	      	   strFormatInfo = "年代格式，比如 2005";
	      	}
	      	if(vtype=="month")         
	      	{       
	      	   thePat = validrule.month;
	      	   strFormatInfo = "月份格式，比如 08";
	      	}
            if(vtype=="day")         
	      	{       
	      	   thePat = validrule.day;
	      	   strFormatInfo = "日子格式，比如 14";
	      	} 
	      	if(vtype=="postcode")         
	      	{       
	      	   thePat = validrule.postcode;
	      	   strFormatInfo = "邮编，比如 100001";
	      	}	      	
	      	if(vtype=="email")         
	      	{       
	      	   thePat = validrule.email;
	      	   strFormatInfo = "电子邮件格式，比如 msm@hotmail.com";
	        }
	      	if(vtype=="phone")         
	      	{       
	      	   thePat = validrule.phone;
	      	   strFormatInfo = "电话号码格式，比如010-67891234";
	      	}
	      	if(vtype=="mobiletel")         
	      	{       
	      	   thePat = validrule.mobiletel;
	      	   strFormatInfo = "手机号码格式，比如13867891234";
	      	}	      	
	      	if(vtype=="ip")       
	      	{       
	      	   thePat = validrule.ip;
	      	   strFormatInfo = "机器ip地址格式，比如 172.22.169.11";
	      	}	      	
	      	if(vtype=="idcard")       
	      	{       
	      	   thePat = validrule.idcard;
	      	   strFormatInfo = "身份证号码，比如15位或者18位数字";
	      	}
	      	if(vtype=="tabledefine")   
	      	{       
	      	   thePat = validrule.tabledefine;
	      	   strFormatInfo = "abc_defgf";
	      	}
	      	 
	      	if(vtype=="LetterStr")
	      	{       
	      	   thePat = validrule.LetterStr;
	      	   strFormatInfo = "纯字母字符串";
	      	}
	      	if(vtype=="NumAndStr")
	      	{       
	      	   thePat = validrule.NumAndStr;
	      	   strFormatInfo = "数字和字母字符串";
	      	}
	      	if(vtype=="NumStr")
	      	{       
	      	   thePat = validrule.NumStr;
	      	   strFormatInfo = "纯数字组成的字符串";
	      	}
            var gotIt = null;
            var message = ""; 	      	
	      	if(thePat!="")
	      	{
	      	        gotIt = thePat.exec(vvalue);
	      	}	
	      	      	 
	      	if(gotIt == null) 
	      	{
	      		    message = elemdescrip + "输入不合法,格式应为：" + strFormatInfo;
	      	}
	      	else
	      	{
	      	    message = "";
	      	}
    return message;
}
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.validate.js");