/************************************************
 *             类名: TimeInputText              *
 * 功能:                                        *
 *   用于接收时间输入                           *
 * 参数:                                        *
 *   containerElement 父容器�?                 *
 *   width 宽�?                                *
 *   height 高�?
 *   value 文字
 *   fontSize 字体大小                          *
 *   fontFamily 字体�?                         *
 *                                              *
 ************************************************/
function TimeInputText(containerElement, value ,width,
    height, fontSize, fontFamily) {

    var pThis = this;
    
    this.textEdit = null;
    
    this.containerElement = containerElement;
    
    this.width = width;
    
    this.height = height;
    
    this.fontSize = fontSize;
    
    this.fontFamily = fontFamily;
    
    this.cursorPos = 0;
    
    this.borderColor = "#96C2F1";
    
    this.value = value;
    

    if(TimeInputText.isNull(containerElement)){
        return ;
    }
    
    if(TimeInputText.isNull(width)){
        return ;
    }
    
    if(TimeInputText.isNull(height)){
        return ;
    }
    
    if(TimeInputText.isNull(fontSize)){
        this.fontSize = 12;
    }
    
    if(TimeInputText.isNull(fontFamily)){
        this.fontFamily = "Fixedsys,Arial"
    }
    
    /**
     * 功能�?
     *   获取当前文本框里的时间�?
     * 参数:
     *   无�?
     * 返回值：
     *   文本框里的时间字符串�?
     **/
    this.getTime = function(){
        
        return this.value;
        
    }
    
    /**
     * 功能:
     *   用于从一个字符串获取有效的日期，如果没有有效的则返回
     *   00:00 
     * 参数:
     *   value 需要获�?
     * 返回�?
     *   true 对的�?
     *   false 不合法�?
     **/
    this.getValidateTime = function(value){

       var arr = value.split(":");
       
       if(arr.length != 2){
           return "00:00";
       }
       
       if(this.isNumeric(arr[0]) == false ||
          this.isNumeric(arr[1]) == false ){
           return "00:00";
       }
       
       var iHours = parseInt(arr[0]);
       if(iHours >= 24 || iHours < 0){
           return "00:00";
       }
       
       var iMunites = parseInt(arr[1]);
       if(iMunites >= 60 || iMunites < 0){
           return "00:00";
       }
       
       var strHours = Appendzero(iHours + "", 2);
       var strMunites = Appendzero(iMunites + "", 2);
       
       return strHours + ":" + strMunites;
         
    }
    
    /**
     * 功能:
     *   用于不足n位自动前面补零的函数�?
     * 参数:
     *   iNumber 需要补零的数字�?
     * 返回值：
     *   补完零后的字符串�?
     **/
    function Appendzero(iNumber, n){
        
        if(iNumber == null){
            iNumber = 0;
        }
        
        iNumber = parseInt(iNumber);
        
        var strNumber = iNumber + "";
        
        while(strNumber.length < n){
            strNumber  = "0" + strNumber;
        }
        
        return strNumber;
    }
    
    
    /**
     * 功能:
     *   判断是不是整�?
     * 参数:
     *   value 需要判断的变量�?
     * 返回�?
     *   true 是数字�?
     *   false 不是数字�?
     **/
    this.isNumeric = function(value){  
        var r = /^\+?[0-9]*$/;
        return r.test(value);
    }
    
    /**
     * 功能:
     *   用于初始化控件�?
     * 参数:
     *   �?
     * 返回�?
     *   �?
     **/
    this.init = function(){
        
        this.value = this.getValidateTime(this.value);
       
        ///////////////////
        //
        // 创建一个文本框�?
        this.textEdit = document.createElement("input");
        this.textEdit.type = "text";
        this.textEdit.value = this.value;
        this.textEdit.style.width = this.width + "px";
        this.textEdit.style.height = this.height + "px";
        this.textEdit.style.cssText = this.textEdit.style.cssText + ";ime-mode:Disabled";
        this.textEdit.style.border = "1px solid " + this.borderColor;
        this.containerElement.appendChild(this.textEdit);
        
        
        ///////////////////
        //
        // 绑定控件事件�?
        if(document.all){
            this.textEdit.attachEvent("onkeydown", this.onKeyDown);
            //this.textEdit.attachEvent("onmousedown", this.onMouseDown);
        }
        else{
            this.textEdit.addEventListener("keydown", this.onKeyDown, false);
            //this.textEdit.addEventListener("mousedown", this.onMouseDown, false);
        }
        
       
    }
    
    /**
     * 功能�?
     *   用于响应鼠标点击事件�?
     * 参数:
     *   e 事件源�?
     * 返回值：
     *   无�?
     **/
    this.onMouseDown = function(e){
        pThis.cursorPos = getCursortPosition(pThis.textEdit);
    }
    
    function replaceChat(source,pos,newChar){
    
        if(pos<0 || pos>=source.length||source.length==0){  
            return source;  
        }
        
        var iBeginPos= 0, iEndPos=source.length;  
        var sFrontPart=source.substr(iBeginPos,pos);  
        var sTailPart=source.substr(pos+1,source.length);  
        var sRet=sFrontPart+newChar+sTailPart;  
        
        return sRet;  
    }  
    
    /**
     * 功能�?
     *   是否是允许输入的扫描码�?
     **/
    this.isAllowInputKey = function(keycode){
       
        if(isTheKeycodeNumeric(keycode) || 
           isTheKeycodeDel(keycode) || 
           isTheKeycodeLeftRight(keycode)){
        
            return true;
        }
    
        return false;
    }
    
    /**
     * 功能�?
     *   根据键盘扫描码获取到字符.
     * 参数:
     *   键盘扫描码�?
     * 返回�?
     *   无�?
     **/
    function getCharFromKeyCode(keycode){
        
        if(keycode >= 96 && keycode <= 105){
           keycode = keycode - 96;
           return String.fromCharCode("0".charCodeAt() + keycode);
        }
        
        return String.fromCharCode(keycode);
        
    }
    
    /**
     * 功能�?
     *   用于响应keypress事件�?
     * 参数:
     *   e 事件�?
     * 返回�?
     *   �?
     **/
    this.onKeyDown = function(e){
    
        var iCursorPos = getCursortPosition(pThis.textEdit);
        
        var keycode = pThis.getKeyCode(e); //获取当前敲入的keycode
        
        if(pThis.isAllowInputKey(keycode) == false){
            pThis.setReturnValueFalse(e);
            return ;
        }
        
        //////////////////////////
        //
        // 如果在第一个字母前
        if(iCursorPos == 0){
            
            if(isTheKeycodeNumeric(keycode) == true){
                
                strKey = getCharFromKeyCode(keycode);
                
                /////////////////
                // 如果小于2，则可以输入到第一�?
                if(parseInt(strKey) <= 2){
                    pThis.setReturnValueFalse(e);
                    pThis.value = replaceChat(pThis.value, 0, strKey);
                    pThis.textEdit.value = pThis.value;
                    setCaretPosition(pThis.textEdit, 1);  
                    return ;                    
                }
                else{
                    pThis.setReturnValueFalse(e);
                    return ;
                }
                
            }
            
            if(isTheKeycodeDel(keycode) || isTheKeycodeLeftRight(keycode)){
                return ;
            }
            
            pThis.setReturnValueFalse(e);
        }
        
        //////////////////////////
        //
        // 如果在第二个字母前�?
        if(iCursorPos == 1){
            
            ///////////////////
            //
            // 是否是数字�?
            if(isTheKeycodeNumeric(keycode) == true){
                var strHours = pThis.value.charAt(0) + getCharFromKeyCode(keycode);
                
                pThis.setReturnValueFalse(e);
                
                if(parseInt(strHours) > 23){
                   return ;
                }
                
                pThis.value = replaceChat(pThis.value, 1, getCharFromKeyCode(keycode));
                
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 3);
                
                return ;
            }
            
            //////////////////////
            //
            // 如果是删除键�?
            if(isTheKeycodeDel(keycode)){
                
                pThis.setReturnValueFalse(e);
                pThis.value = replaceChat(pThis.value, 0, "0");
                
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 0)
            }
            
        }
        
        //////////////////////////
        //
        // 如果在第三个字母前�?
        if(iCursorPos == 2){
            
            
            ///////////////////
            //
            // 是否是数字�?
            if(isTheKeycodeNumeric(keycode) == true){
                
                strKey = getCharFromKeyCode(keycode);
                
                if(parseInt(strKey) >= 6){
                   pThis.setReturnValueFalse(e);
                   pThis.value = replaceChat(pThis.value, 2, "0");
                   setCaretPosition(pThis.textEdit, 3)
                   return ;
                }
                
                pThis.setReturnValueFalse(e);
                pThis.value = replaceChat(pThis.value, 3, strKey);
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 4);
                return ;
            }
            
            //////////////////////
            //
            // 如果是删除键�?
            if(isTheKeycodeDel(keycode)){
                
                pThis.setReturnValueFalse(e);
                pThis.value = replaceChat(pThis.value, 1, "0");
                
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 1)
            }
        }
    
        //////////////////////////
        //
        // 如果在第四个字母前�?
        if(iCursorPos == 3){
        
            ///////////////////
            //
            // 是否是数字�?
            if(isTheKeycodeNumeric(keycode) == true){
              
                strKey = getCharFromKeyCode(keycode);
               
                if(parseInt(strKey) >= 6){
                   pThis.setReturnValueFalse(e);
                   setCaretPosition(pThis.textEdit, 3)
                   return ;
                }
                
                pThis.setReturnValueFalse(e);
                pThis.value = replaceChat(pThis.value, 3, strKey);
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 4);
                return ;
            }

            //////////////////////
            //
            // 如果是删除键�?
            if(isTheKeycodeDel(keycode)){
                
                pThis.setReturnValueFalse(e);
                 
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 2);
                
                return;
            }
            
            
        }
        
        
        //////////////////////////
        //
        // 如果在第五个字母前�?
        if(iCursorPos == 4){
        
            ///////////////////
            //
            // 是否是数字�?
            if(isTheKeycodeNumeric(keycode) == true){
              
                strKey = getCharFromKeyCode(keycode);
                
                
                pThis.setReturnValueFalse(e);
                pThis.value = replaceChat(pThis.value, 4, strKey);
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 5);
                return ;
            }
            
            
            //////////////////////
            //
            // 如果是删除键�?
            if(isTheKeycodeDel(keycode)){
                
                pThis.setReturnValueFalse(e);
                
                pThis.value = replaceChat(pThis.value, 3, "0");
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 3);
                
                return ;
            }

        }
        
        //////////////////////////
        //
        // 如果在第五个字母前�?
        if(iCursorPos == 5){
        
            //////////////////////
            //
            // 如果是删除键�?
            if(isTheKeycodeDel(keycode)){
                
                pThis.setReturnValueFalse(e);
                
                pThis.value = replaceChat(pThis.value, 4, "0");
                pThis.textEdit.value = pThis.value;
                setCaretPosition(pThis.textEdit, 4);
                
                return ;
            }
            
            ///////////////////
            //
            // 是否是数字�?
            if(isTheKeycodeNumeric(keycode) == true){
                pThis.setReturnValueFalse(e);
                return ;
            }
            
        }
        
    /*
        //alert(pThis.textEdit.value)
        var keycode = pThis.getKeyCode(e);
        //alert(keycode);
        alert(getCursortPosition(pThis.textEdit));
        
        if(keycode >= "0".charCodeAt() && keycode <= "9".charCodeAt() || keycode == 8){
        }
        else{
           pThis.setReturnValueFalse(e);
        }
    */   
    }
    
    /**
     * 功能�?
     *   判断是不是数字键被按下�?
     * 参数:
     *   keycode 键盘扫描码�?
     * 返回值：
     *   true 是数字�?
     *   false 不是数字
     **/
    function isTheKeycodeNumeric(keycode){
        
        if((keycode >= "0".charCodeAt() && keycode <= "9".charCodeAt())
           ||(keycode >= 96 && keycode <= 105)){
            return true;
        }
        
        return false;
    }
    
    /**
     * 功能�?
     *   用于判断键盘扫描码是不是删除�?
     * 参数:
     *   keycode 键盘扫描码�?
     * 返回值：
     *   true 是�?
     *   false 不是�?
     **/
    function isTheKeycodeDel(keycode){
        
        if(keycode == 8){
           return true;
        }
        
        return false;
    }
    
    /**
     * 功能:
     *   判断是不是左右键�?
     * 参数:
     *   keycode 键盘扫描码�?
     * 返回值：
     *   true 是左右键�?
     *   false 不是左右�?
     **/
    function isTheKeycodeLeftRight(keycode){
        
        if(keycode == 37 || keycode == 39){
            return true;
        }
        
        return false;
    }
    
    /**
     * 获取光标在控件里的位置�?
     **/
    function getCursortPosition (ctrl) {
    
        var CaretPos = 0;   // IE Support
        
        if (document.selection) {
        
            ctrl.focus ();
            var Sel = document.selection.createRange ();

            Sel.moveStart ('character', - ctrl.value.length);
            CaretPos = Sel.text.length;
        }
        else if (ctrl.selectionStart || ctrl.selectionStart == '0')// Firefox support
             CaretPos = ctrl.selectionStart;
             
       return (CaretPos);
    }
    
    /**
     * 设置光标的位�?
     **/
    function setCaretPosition(ctrl, pos){
        if(ctrl.setSelectionRange)
        {
            ctrl.focus();
            ctrl.setSelectionRange(pos,pos);
        }
        else if (ctrl.createTextRange) {
           var range = ctrl.createTextRange();
           range.collapse(true);
           range.moveEnd('character', pos);
           range.moveStart('character', pos);
          range.select();
        }
    }
    
    /**
     * 功能:
     *   取消输入�?
     * 参数:
     *   e 事件源�?
     * 返回�?
     *   无�?
     **/
    this.setReturnValueFalse = function(e){
    
        if(window.event){
            window.event.returnValue = false;
        }
        else{
            e.preventDefault();
        }
        
    }

    /**
     * 功能�?
     *   用于设置时间�?
     * 参数:
     *   strTime 时间�?
     * 返回值：
     *   无�?
     **/
    this.setTime = function(strTime){
        this.textEdit.value = this.getValidateTime(strTime);
    }
    
    /**
     * 功能�?
     *   用于获取兼容各个浏览器的键盘扫描码�?
     * 参数:
     *   e 事件源�?
     * 返回值：
     *   事件扫描码�?
     **/
    this.getKeyCode = function(e){
    
        var keycode = 0;
        
        if(document.all){
           keycode = event.keyCode;
        }
        else{
           keycode = e.which;
        }
        
        return keycode;
    }
    
    /**
     * 功能:
     *   设置该控件的表单名�?
     * 参数:
     *   strFormName 控件的表单名�?
     * 返回值：
     *   无�?
     **/
    this.setFormName = function(strFormName){
        
        if(this.textEdit == null){
            return ;
        }
        
        
        this.textEdit.name = strFormName;
    }
    
    
    this.init();
  
}


/**
 * 功能:
 *   用于判断变量是否为null.
 * 参数:
 *   var1 需要判断的变量�?
 * 返回�?
 *   true 是null
 *   false 非null
 **/
TimeInputText.isNull = function(var1){

    if(typeof(var1) == "undefined" || var1 == null){
        return true;
    }
    
    return false;
}

/**
 * 功能:
 *   用于获取可能没定义的参数�?
 * 参数:
 *   var1 变量�?
 * 返回�?
 *   如果�?undefined 自动变null
 **/
TimeInputText.getVarIfUndefine = function(var1){
    
    var bRet = TimeInputText.isNull(var1);
    
    if(bRet == true){
        return null;
    }
 
    return var1;
}

