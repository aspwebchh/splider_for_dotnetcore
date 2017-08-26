public class MailSend{
    public static bool Send(string title, string content ) {
            Email email = new Email();
            email.mailFrom = "chhblog@163.com";
            email.mailPwd = "";
            email.mailSubject = title;
            email.mailBody = content;
            email.isbodyHtml = true;    //是否是HTML
            email.host = "smtp.163.com";//如果是QQ邮箱则：smtp:qq.com,依次类推
            email.mailToArray = new string[] { "aspwebchh@hotmail.com"};//接收者邮件集合
           // email.mailCcArray = new string[] { "******@qq.com" };//抄送者邮件集合
            return email.Send();
    }
}