using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear lista de videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learning C#", "Juan Pérez", 600);
        video1.AddComment(new Comment("María", "Excellent explanation, thank you!"));
        video1.AddComment(new Comment("Pedro", "Very useful, I learned a lot."));
        video1.AddComment(new Comment("Lucía", "Could you do one on LINQ?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Fundamentals of OOP", "Ana López", 750);
        video2.AddComment(new Comment("Carlos", "It helped me with my homework."));
        video2.AddComment(new Comment("Sofía", "The example of inheritance is crystal clear."));
        video2.AddComment(new Comment("Miguel", "Could you explain polymorphism?"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Encapsulation in C#", "Luis García", 500);
        video3.AddComment(new Comment("Elena", "Now I understand the concept, thank you."));
        video3.AddComment(new Comment("Andrés", "Good video, straight to the point."));
        video3.AddComment(new Comment("Patricia", "I look forward to more videos like this."));
        videos.Add(video3);

        // Mostrar información de cada video
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }

        Console.ReadLine();
    }
}
