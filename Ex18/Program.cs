using Ex18OutraVersao;

Comment comment1 = new("Have a nice trip!");
Comment comment2 = new("Wow, that's awesome!");

Post post = new
    (DateTime.Parse("21/06/2018 13:05:44"),
    "Traveling to New Zealand ",
    "I'm going to visit this wonderful country",
    12);

post.AddComment(comment1);
post.AddComment(comment2);

Comment comment3 = new("Good night!");
Comment comment4 = new("May the Force be with you.");

Post post2 = new(
    DateTime.Parse("28/07/2018 23:14:19"),
    "Good night guys",
    "See you tomorrow",
    5
);

post2.AddComment(comment3);
post2.AddComment(comment4);

Console.WriteLine(post.ToString());
Console.WriteLine(post2.ToString());
