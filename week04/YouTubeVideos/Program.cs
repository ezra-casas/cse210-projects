using System;
using System.Collections.Generic;

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetCommentText()
    {
        return _commentText;
    }
}

// video class to encapsulate (enclose) video details and comments
public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //  list to store videos
        List<Video> videos = new List<Video>();

        // video 1
        Video video1 = new Video("Learning C# Basics", "TechGuru", 600);
        video1.AddComment(new Comment("Alice123", "Great tutorial, very clear!"));
        video1.AddComment(new Comment("BobCode", "Thanks for the examples!"));
        video1.AddComment(new Comment("CharlieDev", "Can you cover LINQ next?"));
        video1.AddComment(new Comment("DanaLearn", "Super helpful, thanks!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Advanced C# Techniques", "CodeMaster", 900);
        video2.AddComment(new Comment("EveTech", "Loved the async explanation!"));
        video2.AddComment(new Comment("FrankCode", "The delegate part was tricky."));
        video2.AddComment(new Comment("GraceDev", "Awesome content!"));
        videos.Add(video2);

        //  Video 3
        Video video3 = new Video("C# Project Walkthrough", "DevPro", 1200);
        video3.AddComment(new Comment("HankLearn", "This project was fun to follow!"));
        video3.AddComment(new Comment("IvyCode", "Clear and concise, thanks!"));
        video3.AddComment(new Comment("JackTech", "Please make more like this."));
        video3.AddComment(new Comment("KaraDev", "Really well explained!"));
        videos.Add(video3);

        //Video 4
        Video video4 = new Video("C# Tips and Tricks", "TechBit", 450);
        video4.AddComment(new Comment("LiamCode", "These tips are awesome!"));
        video4.AddComment(new Comment("MiaLearn", "Short and sweet, loved it!"));
        video4.AddComment(new Comment("NoahDev", "Very practical advice."));
        videos.Add(video4);

        // Display information for each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            Console.WriteLine();
        }
    }
}
