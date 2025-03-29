using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create New Videos
        Video video1 = new Video("Python for beginners", "PyLabs", 380);
        video1.AddComment(new Comment("John_91", "useful, very detailed information!"));
        video1.AddComment(new Comment("Alice", "I feel more confident to start trying python"));
        video1.AddComment(new Comment("OneAndy", "This video improved my life expectancy"));
        video1.AddComment(new Comment("Gretter5593", "One of the best python videos that I've ever seen!"));

        Video video2 = new Video("Cooking with Lucie", "Chef Lucie", 623);
        video2.AddComment(new Comment("Amarantha", "I love her cooking ♥, I love the recipes she prepares."));
        video2.AddComment(new Comment("Alice", "I feel more confident to start trying python"));
        video2.AddComment(new Comment("Rekzmarsheey", "It a good look, I love it!"));
        video2.AddComment(new Comment("Lady Shanice", "Looks great"));

        Video video3 = new Video("Travel Vlog WhiteWater Canada", "Adventure Atlanta", 950);
        video3.AddComment(new Comment("Ergok", "Mark is adventurous, and very brave to go there."));
        video3.AddComment(new Comment("Louis", "That trip was exciting, I would like to know how I can participate."));
        video3.AddComment(new Comment("George Kennt", "Nice!"));

        Video video4 = new Video("Convex neural networks in Jupyter Notebook", "Ringa Tech", 895);
        video4.AddComment(new Comment("Gabriel Augusto", "Not all existing courses on IA explain it as well and as simply as this one."));
        video4.AddComment(new Comment("Inakilesca", "very didactic, I am glad to have a series on the subject in Spanish and so clear, success!"));
        video4.AddComment(new Comment("Braian Ballhrost", "First time I see a video that with a simple example explained very well what a neural network is. Thanks my brother! Greetings from Argentina"));
        video4.AddComment(new Comment("Jonathancoder", "I understood it perfectly, it's the first time I see neural networks with JS."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}, Author: {video.GetAuthor()}, {video.GetLengthInMinutesAndSeconds()}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"   - {comment.DisplayComment()}");
            }
            Console.WriteLine();
        }
    }
}