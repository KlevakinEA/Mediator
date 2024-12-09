User user_1 = new User("User_1");
User user_2 = new User("User_2");
Chat chat_1 = new Chat();
Chat chat_2 = new Chat();
Console.WriteLine(user_1.recieveMessage(chat_1));
user_1.sendMessage("Text.", "User_2", chat_1);
Console.WriteLine();

chat_1.exitChat("User_1");
chat_1.enterChat("User_1");
Console.WriteLine();

chat_1.enterChat("User_1");
Console.WriteLine(user_1.recieveMessage(chat_1));
user_1.sendMessage("Text.", "User_2", chat_1);
Console.WriteLine();

chat_1.enterChat("User_2");
user_1.sendMessage("Text.", "User_2", chat_1);
user_1.sendMessage("Text.", "User_2", chat_1);
Console.WriteLine(user_2.recieveMessage(chat_2));
Console.WriteLine(user_2.recieveMessage(chat_1));
Console.WriteLine(user_2.recieveMessage(chat_1));
Console.WriteLine(user_2.recieveMessage(chat_1));
user_1.sendMessage("Text.", "User_2", chat_1);
Console.WriteLine(user_1.recieveMessage(chat_1));
Console.WriteLine();

chat_1.exitChat("User_2");
user_1.sendMessage("Text.", "User_2", chat_1);
Console.WriteLine(user_2.recieveMessage(chat_1));
Console.WriteLine();

chat_1.messageHistory("User_2");
Console.WriteLine();

chat_2.messageHistory("User_2");




class User
{
    private protected string Name;
    public void sendMessage(string message, string reciever, Chat chat) { Console.WriteLine(chat.sendMessage(message, reciever, Name)); }
    public string recieveMessage(Chat chat) { return chat.checkMessages(Name); }
    public User(string name) { this.Name = name; }
}


class Chat
{
    private protected List<string> users = new List<string>();
    private protected List<Message> messages = new List<Message>();
    public string checkMessages(string username) { if (!users.Contains(username)) return "Unauthorised access."; else foreach (Message i in messages) if (i.reciever.Equals(username, StringComparison.Ordinal) && !i.is_recieved) { i.is_recieved = true; return i.text; } return "No messages."; }
    public string sendMessage(string message, string reciever, string username) { if (!users.Contains(username)) Console.WriteLine("Unauthorised access."); else { if (!users.Contains(reciever)) Console.WriteLine("There're no such users."); else { messages.Add(new Message(message, reciever)); return "Message sent."; } } return ""; }
    public void enterChat(string username) { if (users.Contains(username)) Console.WriteLine("There's already user with that username."); else users.Add(username); }
    public void exitChat(string username) { if (!users.Contains(username)) Console.WriteLine("There're no such users."); else users.Remove(username); }
    public void messageHistory(string username) { foreach (Message i in messages) if (i.reciever.Equals(username, StringComparison.Ordinal) && i.is_recieved) Console.WriteLine(i.text); }
}


class Message
{
    public string text;
    public string reciever;
    public bool is_recieved = false;
    public Message(string text, string reciever) {  this.text = text; this.reciever = reciever; }
}