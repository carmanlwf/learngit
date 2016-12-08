//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Reflection;
//using Microsoft.Office.Interop.Outlook;
//using OutLook = Microsoft.Office.Interop.Outlook;
//using jmail;

//namespace Ncl.PM
//{
//    public class MailHelper
//    {
//        private string _mailfrom;

//        public string MailFrom
//        {
//            get { return _mailfrom; }
//            set { _mailfrom = value; }
//        }
//        private string _mailto;

//        public string MailTo
//        {
//            get { return _mailto; }
//            set { _mailto = value; }
//        }
//        private string _mailsubject;

//        public string MailSubject
//        {
//            get { return _mailsubject; }
//            set { _mailsubject = value; }
//        }
//        private string _mailbody;

//        public string MailBody
//        {
//            get { return _mailbody; }
//            set { _mailbody = value; }
//        }

//        private string _mailcc;

//        public string MailCC
//        {
//            get { return _mailcc; }
//            set { _mailcc = value; }
//        }
//        private string _mailbcc;

//        public string MailBCC
//        {
//            get { return _mailbcc; }
//            set { _mailbcc = value; }
//        }

//        protected OutLook.Application GetOutLookApp()
//        {
//            OutLook.Application outlook = new Application();
//            return outlook;
//        }

//        protected MailItem GetMailItem(OutLook.Application outlook)
//        {
//            MailItem mItem = (MailItem)outlook.CreateItem(OlItemType.olMailItem);
//            mItem.To = _mailto;
//            ///抄送
//            mItem.CC = _mailto;
//            ///密送
//            mItem.BCC = _mailto;

//            mItem.Body = _mailbody;

//            mItem.BodyFormat = OlBodyFormat.olFormatHTML;

//            return mItem;
//        } 
//    }

//    public class JMailHelper
//    {
//        string  _smtpserver;
//        string  _from;
//        string  _to;
//        string  _subject;
//        string  _content;
//        string _username;
//        string _password;
//        string [] _attatchment;

//        public JMailHelper(string _smtpserver, string _from, string _to, string _subject, string _content, string _username, string _password, string[] _attatchment)
//        {
//            smtpserver=_smtpserver;
//            from=_from;
//            to=_to;
//            subject=_subject;
//            content=_content;
//            username=_username;
//            password=_password;
//            attatchment=_attatchment;
//        }
//        public string smtpserver
//        {
//            get
//            {
//               return _smtpserver;
//            }
//            set
//            {
//                _smtpserver=value;
//            }
//        }
//        public string from
//        {
//            get
//            {
//                return _from;
//            }
//            set
//            {
//                _from=value;
//            }
//        }
//        public string to
//        {
//            get
//            {
//                return _to;
//            }
//            set
//            {
//                _to=value;
//            }

//        }
//        public string subject
//        {
//            get
//            {
//                return _subject;
//            }
//            set
//            {
//                _subject=value;
//            }
//        }
//        public string content
//        {
//            get
//            {
//                return _content;
//            }
//            set
//            {
//                _content=value;
//            }
//        }
//        public string username
//        {
//            get
//            {
//                return _username;
//            }
//            set
//            {
//                _username=value;
//            }
//        }
//        public string password
//        {
//            get
//            {
//                return _password;;
//            }
//            set
//            {
//                _password=value;
//            }

//        }
//        public string [] attatchment
//        {
//            get
//            {
//                return  _attatchment;
//            }
//            set
//            {
//                _attatchment=value;
//            }
//        }
//    }

//    public class MyJmail
//    {
//        private MyJmail()
//        {

//        }
//        public static bool SendMail(JMailHelper mymail)
//        {
//            try
//            {

//                Message sem = new Message();
//                sem.From = mymail.from;                //发件人
//                sem.AddRecipient(mymail.to, " ", " ");//收件人
//                sem.MailServerPassWord = mymail.password;//登陆密码
//                sem.MailServerUserName = mymail.username;//用户名
//                sem.Subject = mymail.subject;//主题
//                sem.Body = mymail.content;//内容
//                if (mymail.attatchment.Length != 0)
//                    for (int i = 0; i < mymail.attatchment.Length; i++)
//                        sem.AddAttachment(mymail.attatchment[i], true, null);//附件
//                sem.Send(mymail.smtpserver, false);//发送
//                sem.Close();
//            }
//            catch
//            {
//                return false;
//            }
//            return true;
//        }
//    }
//}
