


/*
*******����˵����

��ҳ���ϼ��룺
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

�ؼ�����Ҫ��ӵ����ԣ�
vmode���Ƿ�Ϊ�յ���֤��
vtype����֤�ؼ�ʹ�õĹ���
vdisp��������ʾ�еĿؼ�������
vtextarea���Ƿ���֤�ַ����ĳ��ȡ�
maxlength���ַ�������󳤶ȡ�
voperate���Ƚ���֤ʹ�õ���֤�����Լ�ʹ���Զ���������ʽ
passvalue����Χֵ
extendname�������ַ���
max����Χ����
min����Χ����
to�����ȽϵĿؼ���
regexp���Զ���������ʽ

���Թ���
�ؼ��ϲ�����vmode���ԣ�����ʾ�ؼ���Ϊ�գ�
�ؼ��ϲ�����vdisp���ԣ��������ʾ�еĿؼ�������ϢΪ�ؼ���id��
�ؼ��ϲ�����vtype���ԣ�����ʾ���Կؼ����й�����֤��
�ؼ��ϲ�����vtextarea���ԣ�����ʾ���Կؼ������ַ������ȵ���֤��
vtextarea��maxlength����ɶ�ʹ�ã�

vmode��ֵ��
not null��������Ϊ��

vtype��ֵ��
chinese��������
english����Ӣ����ĸ
number��������������
integer��������
float����������
double����ʵ��
string��������������ϵ��ַ���
int����������
minusint���������������硡-123
date���������ͣ����� 2004-08-12
time����ʱ���ͣ����硡08:37:29
datehm��������ʱ���ͣ����� 2004-08-12 12:25
datetime��������ʱ���ͣ����硡2004-08-12 08:37:29
year���������ʽ������ 2005
month�����·ݸ�ʽ������ 08
day�������Ӹ�ʽ������ 14
postcode�����ʱ࣬���� 100001
email���������ʼ���ʽ������ msm@hotmail.com
phone�����绰�����ʽ������010-67891234
mobiletel�����ֻ������ʽ������13867891234
ip��������ip��ַ��ʽ������ 172.22.169.11
idcard�������֤���룬����15λ����18λ����
tabledefine����abc_defgf
Let terStr��������ĸ�ַ���
NumAndStr�������ֺ���ĸ�ַ���
NumStr������������ɵ��ַ���

vtextarea��ֵ��
yes������Ҫ��֤����

voperate��ֵ��
repeat����֤���ؼ������Ƿ�һ��
rangeint����֤�ؼ���ֵ��Χ(int)
    max����Χ����
    min����Χ����
rangestr����֤�ؼ���ֵ��Χ(string)
    max����Χ����
    min����Χ����
largestr���ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڵ�ǰ�ؼ�(string)
largeequalstr���ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڻ��ߵ��ڵ�ǰ�ؼ�(string)
largeint���ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڵ�ǰ�ؼ�(int)
largeintvalue���ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڵ�ǰ�ؼ�һ����ֵ(int)
    passvalue����Χֵ
largeequalint���ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڻ��ߵ��ڵ�ǰ�ؼ�(int)
extend���ؼ�ֵ�Ƿ�����ض��ַ���
    extendname�������ַ���
custom���Զ���������ʽ
    regexp���Զ���������ʽ
blank�� ��֤���ؼ�״̬�Ƿ�һ�£�����ͬʱΪ�ջ���ͬʱ��ֵ��
largemonth���ȽϿؼ���ֵ��Ŀ��ؼ���ֵ������ڵ�ǰ�ؼ�һ����
smallmonth���ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڵ�ǰ�ؼ�һ����
largemoremonth:�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ������ڵ�ǰ�ؼ�n����(�������moremonth)
*/

/*

********��֤��ʽһ��
����Form��֤

������֤�İ�ť����Ҫ��ӵ��¼�
HtmlControl : onclick = "if (������(����...))"
WebContrl : OnClientClick="return ������(����...);"

��֤�ĺ���������

doSingleMessageBoxValidate( vform )������MessageBox��ʽ���д�����ʾ��ͬʱֻ��ʾ��һ��
doAllMessageBoxValidate( vform )������MessageBox��ʽ���д�����ʾ��ͬʱ��ʾ����
doSummaryValidate( vform , SummaryControl )������Summary��ʽ���д�����ʾ��ͬʱ��ʾ����
doFormValidate( vform , isMessageBox , isSummary , isShowAll , SummaryControl )

�������壺
vform������Ҫ��֤��Form��
isMessageBox����������ʾ�Ƿ�ΪMessageBox��ʽ
isSummary����������ʾ�Ƿ�ΪSummary��ʽ
isShowAll�����Ƿ�һ������ʾ���д���
SummaryControl������ʾ������Ϣ�Ŀؼ�

ע��isSummary��SummaryControl����ɶ�ʹ��


�÷�������
��Ҫ��֤�Ŀؼ���<input id="name" type="text" runat="server" vmode="not null" vtype="number" vdisp="����"/>
������֤��HtmlControl��<input type="button" value="submit" onclick="if (doAllMessageBoxValidate(form1))" onserverclick="tt_onserverclick" runat="server" id="Button1" />
������֤��WebContrl��<asp:Button ID="btn" Text="btn" OnClientClick="return doAllMessageBoxValidate(form1);" runat="server" OnClick="btn_Click" />
*/

/*
********��֤��ʽ����
���� asp.net CustomValidator��֤�ؼ���ʽ��֤

CustomValidator��֤�ؼ�����˵����
ValidateEmptyText�������ؼ�ֵΪ�յ�ʱ���Ƿ������֤
Display����������Ϣռλ��ʽ
ClientValidationFunction������֤������ע���ñ��ʣӣ���֤����Ϊ��doAspNetValidate��

��֤�ĺ���������
doAspNetValidate(oSrc, args)

�÷�������
��Ҫ��֤�Ŀؼ���<input id="name" type="text" runat="server" vmode="not null" vtype="number" vdisp="����"/>
��֤�ؼ���<asp:CustomValidator ValidateEmptyText="true" ID="nameCustomValidator1" Display="Static" runat="server" ClientValidationFunction="doAspNetValidate" ErrorMessage="CustomValidator" ControlToValidate="name"></asp:CustomValidator>

*/





/*

����Ϊ����ʵ��

*/

//��ͨForm��ʽ��֤
//��MessageBox��ʽ���д�����ʾ��ͬʱֻ��ʾ��һ��
function doSingleMessageBoxValidate( vform )
{
    if (doFormValidate(vform , true , null  , null , null))
        return true;
    else
        return false;     
} 

//��ͨForm��ʽ��֤
//��MessageBox��ʽ���д�����ʾ��ͬʱ��ʾ����
function doAllMessageBoxValidate( vform )
{
    if (doFormValidate(vform , true , null  , true , null))
        return true;
    else
        return false; 
} 

//��ͨForm��ʽ��֤
//��Summary��ʽ���д�����ʾ��ͬʱ��ʾ����
//SummaryControl��Ϊ��ʾ���д�����Ϣ�Ŀؼ�
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
 
//��ͨForm��ʽ��֤
function doFormValidate( vform , isMessageBox , isSummary , isShowAll , SummaryControl ) 
{
	var elems = vform.elements;
	var frmLen = elems.length;
	var thePat = "";
	var strFormatInfo = "";
	var errormessage = new Array();
	var j = 0;
	
	//����ÿһ��FROMԪ��
	for(var i=0;i<frmLen;i++) 
	{
		var _elem = elems[i];
		var elemdescrip = ValidateDescrip( _elem.vdisp , _elem);
		errormessage[j] = "";
		
		//��ÿһ��FROMԪ�ؽ�����֤      
        errormessage[j] = errormessage[j] + CheckElem(_elem , elemdescrip);
	    
	    //��ʾ����������Ϣ  	
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
	
	//��ʾȫ��������Ϣ
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
	            allerrormessage = allerrormessage + "��" + errormessage[k] + "\r\n";
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



//asp.net CustomValidator��֤�ؼ���ʽ��֤
function doAspNetValidate(oSrc, args)
{
  var b = document.getElementById(oSrc.controltovalidate);
  var elemdescrip = ValidateDescrip( b.vdisp , b);
  var message = "";
  
  //Ϊ�ռ��
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
		
		//Ϊ�ռ��                
        errormessage = ValidateNull(_elem.value , _elem.vmode , elemdescrip);	 
        
        //���ͼ��                  
		if(_elem.vtype != null) 
		{
			errormessage = errormessage + ValidateType( _elem.vtype , _elem.value , elemdescrip); 		      	      	
	    }
	    
	    //���ȼ��
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

//������֤
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
            message = elemdescrip + "�����ֵ����̫��������" + imaxlength + "���ַ�";
        }
    }
    return message;
}

//Ϊ����֤
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
            errormessage = elemdescrip + "����Ϊ��!";
        }
    }
    return errormessage;	
}

function ValidateCompare(_elem , elemdescrip)
{
    var errormessage = "";
    var tocontrol = document.getElementById(_elem.to);
    //��֤���ؼ������Ƿ�һ��
    if(_elem.voperate=="repeat")         
	{       	      	  
	    if(_elem.value != tocontrol.value)
	        {
	      	    _elem.focus();
	      	    errormessage = elemdescrip + "�����������롡" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "����һ�£�";
	      		return errormessage;
	      	}
	}
	
	//��֤���ؼ�״̬�Ƿ�һ�£�ͬʱΪ�ջ���ͬʱ��ֵ��
	if (_elem.voperate == "blank")
	{
	    if (!validatenull(_elem.value))
	    {
	        if ( validatenull(tocontrol.value))
	        {
	            _elem.focus();
	      	    errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "������Ϊ�գ�";
	      		return errormessage;
	        }
	    }
	    else
	    {
	        if ( !validatenull(tocontrol.value))
	        {
	            _elem.focus();
	      	    errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "������Ϊ�գ�";
	      		return errormessage;
	        }
	    }
	}
	
	//��checkbox����ѡ����ȽϿؼ�����Ϊ��
	if (_elem.voperate == "checked")
	{
	    if (!_elem.checked)
	    {
	        if ( validatenull(tocontrol.value))
	        {
	            _elem.focus();
	      	    errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "������Ϊ�գ�";
	      		return errormessage;
	        }
	    }
	    else
	    {
	        if ( !validatenull(tocontrol.value))
	        {
	            _elem.focus();
	      	    errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "������Ϊ�գ�";
	      		return errormessage;
	        }
	    }
	}
	
	//��֤�ؼ���ֵ��Χ(int)
	if(_elem.voperate=="rangeint")         
	      	{        	      	      	  
	      	   if(parseInt(_elem.value) > parseInt(_elem.max) || parseInt(_elem.value) < parseInt(_elem.min))
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "��������" + _elem.min + " -- " + _elem.max + "���ķ�Χ��";
	      		     return errormessage;
	      	   }
	      	}
	
	//��֤�ؼ���ֵ��Χ(string)      	
	if(_elem.voperate=="rangestr")         
	      	{  	      		      	      	      	  
	      	   if(_elem.value > _elem.max || _elem.value < _elem.min)
	      	   {
	      	        _elem.focus();
	      	        errormessage = elemdescrip + "��������" + _elem.min + " -- " + _elem.max + "���ķ�Χ��";
	      		    return errormessage;
	      	   }
	      	} 
	
	//�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڵ�ǰ�ؼ�(string)     	
    if(_elem.voperate=="largestr")         
	      	{       	      	  
	      	   if(_elem.value <= document.getElementById(_elem.to).value)
	      	   {
                    _elem.focus();
                    errormessage = elemdescrip + "��������ڡ�" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "����ֵ��";
	      		    return errormessage;
	      	   }
	      	}
	      	
    //�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڻ��ߵ��ڵ�ǰ�ؼ�(string)
    if(_elem.voperate=="largeequalstr")         
	      	{       	      	  
	      	   if(_elem.value < document.getElementById(_elem.to).value)
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "��������ڻ��ߵ��ڡ�" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "����ֵ��";
	      		     return errormessage;
	      	   }
	      	}
	 
	 //�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڵ�ǰ�ؼ�(int)     	
	 if(_elem.voperate=="largeint")         
	      	{       	      	  
	      	   if(parseInt(_elem.value) <= parseInt(document.getElementById(_elem.to).value))
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "��������ڡ�" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "����ֵ��";
	      		     return errormessage;
	      	   }
	      	}
	 
	 //�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڵ�ǰ�ؼ�һ����ֵ(int)     	    	
	 if(_elem.voperate=="largeintvalue")         
	      	{       	      	  
	      	   if((parseInt(_elem.value) + parseInt(_elem.passvalue)) <= parseInt(tocontrol.value))
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "����ֵ������ڡ�" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "����ֵ��ȥ��" + _elem.passvalue ;
	      		     return errormessage;
	      	   }
	      	} 
	 
	 //�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ������ڵ�ǰ�ؼ�һ���� 
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
	      	         errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "��������ڡ�" + elemdescrip + "��һ���£�";
	      		     return errormessage;
	      	   }
	      	}	
	      	
	 //�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ������ڵ�ǰ�ؼ�һ���� 
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
	      	         errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "��������ڡ�" + elemdescrip + moremonth + "���£�";
	      		     return errormessage;
	      	   }
	      	}      	    	 
	
	//�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ������ڵ�ǰ�ؼ�һ����
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
	      	         errormessage = ValidateDescrip( tocontrol.vdisp , tocontrol) + "������С�ڡ�" + elemdescrip + "��һ���£�";
	      		     return errormessage;
	      	   }
	      	}
	
	//�ȽϿؼ���ֵ��Ŀ��ؼ���ֵ����С�ڻ��ߵ��ڵ�ǰ�ؼ�(int)          	
    if(_elem.voperate=="largeequalint")         
	      	{       	      	  
	      	   if(parseInt(_elem.value) < parseInt(document.getElementById(_elem.to).value))
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "��������ڻ��ߵ��ڡ�" + ValidateDescrip( tocontrol.vdisp , tocontrol) + "����ֵ��";
	      		     return errormessage;
	      	   }
	      	}   
	      	
    //�ؼ�ֵ�Ƿ�����ض��ַ���
    if(_elem.voperate=="extend")         
	      	{       	      	    
	      	   if((_elem.value).lastIndexOf(_elem.extendname)< 0)
	      	   {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "����������ַ�����" + _elem.extendname;
	      		     return errormessage;
	      	   }
	      	} 
	
	//�Զ���������ʽ      	
    if(_elem.voperate=="custom")         
	      	{
	      	    if ( _elem.value != null && _elem.value != "")  
	      	    {     	      	    
	      	     if(!RegExp(_elem.regexp,"g").test(_elem.value))
	      	     {
	      	         _elem.focus();
	      	         errormessage = elemdescrip + "��������������ʽ����" + _elem.extendname + "����Ҫ�󣡡�";
	          		 return errormessage;
	      	     }
	      	   }
	      	}
    return errormessage; 
}

//������֤
function ValidateType(vtype , vvalue  , elemdescrip)
{
    var thePat;
    var strFormatInfo;
    var typelist = new Array();
	      	if(vtype=="chinese")
	      	{       
	      	   thePat = validrule.chinese;
	      	   strFormatInfo = "����";
	      	}
	      	if(vtype=="english")
	      	{       
	      	   thePat = validrule.english;
	      	   strFormatInfo = "Ӣ����ĸ";
	      	}
	      	if(vtype=="number")
	      	{       
	      	   thePat = validrule.number;
	      	   strFormatInfo = "����������";
	      	}
	      	if(vtype=="integer")
	      	{       
	      	   thePat = validrule.integer;
	      	   strFormatInfo = "����";
	      	}
	      	if(vtype=="float")
	      	{       
	      	   thePat = validrule.float;
	      	   strFormatInfo = "������";
	      	}
	      	if(vtype=="double")
	      	{       
	      	   thePat = validrule.double;
	      	   strFormatInfo = "ʵ��";
	      	}
	      	if(vtype=="string")
	      	{       
	      	   thePat = validrule.string;
	      	   strFormatInfo = "����������ϵ��ַ���";
	      	}
	      	if(vtype=="int")         
	      	{       
	      	   thePat = validrule.int;
	      	   strFormatInfo = "������";
	      	}
	      	if(vtype=="minusint")         
	      	{       
	      	   thePat = validrule.minusint;
	      	   strFormatInfo = "������������-123";
	      	}
	      	if(vtype=="date")         
                {       
	      	   thePat = validrule.date;
	      	   strFormatInfo = "�����ͣ����� 2004-08-12";
	      	}
	      	if(vtype=="time")         
	      	{       
	      	   thePat = validrule.time;
	      	   strFormatInfo = "ʱ���ͣ�����08:37:29";
	      	}
	      	if(vtype=="datehm")         
                {       
	      	   thePat = validrule.datehm;
	      	   strFormatInfo = "����ʱ���ͣ����� 2004-08-12 12:25";
	      	}	      	 
	      	if(vtype=="datetime")         
	      	{       
	      	   thePat = validrule.datetime;
	      	   strFormatInfo = "����ʱ���ͣ�����2004-08-12 08:37:29";
	      	}
            if(vtype=="year")         
	      	{       
	      	   thePat = validrule.year;
	      	   strFormatInfo = "�����ʽ������ 2005";
	      	}
	      	if(vtype=="month")         
	      	{       
	      	   thePat = validrule.month;
	      	   strFormatInfo = "�·ݸ�ʽ������ 08";
	      	}
            if(vtype=="day")         
	      	{       
	      	   thePat = validrule.day;
	      	   strFormatInfo = "���Ӹ�ʽ������ 14";
	      	} 
	      	if(vtype=="postcode")         
	      	{       
	      	   thePat = validrule.postcode;
	      	   strFormatInfo = "�ʱ࣬���� 100001";
	      	}	      	
	      	if(vtype=="email")         
	      	{       
	      	   thePat = validrule.email;
	      	   strFormatInfo = "�����ʼ���ʽ������ msm@hotmail.com";
	        }
	      	if(vtype=="phone")         
	      	{       
	      	   thePat = validrule.phone;
	      	   strFormatInfo = "�绰�����ʽ������010-67891234";
	      	}
	      	if(vtype=="mobiletel")         
	      	{       
	      	   thePat = validrule.mobiletel;
	      	   strFormatInfo = "�ֻ������ʽ������13867891234";
	      	}	      	
	      	if(vtype=="ip")       
	      	{       
	      	   thePat = validrule.ip;
	      	   strFormatInfo = "����ip��ַ��ʽ������ 172.22.169.11";
	      	}	      	
	      	if(vtype=="idcard")       
	      	{       
	      	   thePat = validrule.idcard;
	      	   strFormatInfo = "���֤���룬����15λ����18λ����";
	      	}
	      	if(vtype=="tabledefine")   
	      	{       
	      	   thePat = validrule.tabledefine;
	      	   strFormatInfo = "abc_defgf";
	      	}
	      	 
	      	if(vtype=="LetterStr")
	      	{       
	      	   thePat = validrule.LetterStr;
	      	   strFormatInfo = "����ĸ�ַ���";
	      	}
	      	if(vtype=="NumAndStr")
	      	{       
	      	   thePat = validrule.NumAndStr;
	      	   strFormatInfo = "���ֺ���ĸ�ַ���";
	      	}
	      	if(vtype=="NumStr")
	      	{       
	      	   thePat = validrule.NumStr;
	      	   strFormatInfo = "��������ɵ��ַ���";
	      	}
            var gotIt = null;
            var message = ""; 	      	
	      	if(thePat!="")
	      	{
	      	        gotIt = thePat.exec(vvalue);
	      	}	
	      	      	 
	      	if(gotIt == null) 
	      	{
	      		    message = elemdescrip + "���벻�Ϸ�,��ʽӦΪ��" + strFormatInfo;
	      	}
	      	else
	      	{
	      	    message = "";
	      	}
    return message;
}
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.validate.js");