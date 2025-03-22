using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a Scripture Mastery Passage Collection
        List<List<string>> scriptureMasteryPassage = new List<List<string>>();
        scriptureMasteryPassage.Add(new List<string> { "Moses", "1:39", "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man." });
        scriptureMasteryPassage.Add(new List<string> { "Matthew", "5:14-16", "14 Ye are the light of the world. A city that is set on an hill cannot be hid. 15 Neither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house. 16 Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven." });
        scriptureMasteryPassage.Add(new List<string> { "1 Nephi", "3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them." });
        scriptureMasteryPassage.Add(new List<string> { "Moses", "7:18", "And the Lord called his people Zion, because they were of one heart and one mind, and dwelt in righteousness; and there was no poor among them." });
        scriptureMasteryPassage.Add(new List<string> { "Matthew", "11:28-30", "28 Come unto me, all ye that labour and are heavy laden, and I will give you rest. 29 Take my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls. 30 For my yoke is easy, and my burden is light." });
        scriptureMasteryPassage.Add(new List<string> { "2 Nephi", "2:25", "Adam fell that men might be; and men are, that they might have joy." });
        scriptureMasteryPassage.Add(new List<string> { "Doctrine and Covenants", "1:37-38", "37 Search these commandments, for they are true and faithful, and the prophecies and promises which are in them shall all be fulfilled. 38 What I the Lord have spoken, I have spoken, and I excuse not myself; and though the heavens and the earth pass away, my word shall not pass away, but shall all be fulfilled, whether by mine own voice or by the voice of my servants, it is the same." });
        scriptureMasteryPassage.Add(new List<string> { "Abraham", "3:22-23", "22 Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; and among all these there were many of the noble and great ones; 23 And God saw these souls that they were good, and he stood in the midst of them, and he said: These I will make my rulers; for he stood among those that were spirits, and he saw that they were good; and he said unto me: Abraham, thou art one of them; thou wast chosen before thou wast born." });
        scriptureMasteryPassage.Add(new List<string> { "2 Nephi", "2:27", "Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself." });
        scriptureMasteryPassage.Add(new List<string> { "Genesis", "1:26-27", "26 And God said, Let us make man in our image, after our likeness: and let them have dominion over the fish of the sea, and over the fowl of the air, and over the cattle, and over all the earth, and over every creeping thing that creepeth upon the earth. 27 So God created man in his own image, in the image of God created he him; male and female created he them." });
        scriptureMasteryPassage.Add(new List<string> { "2 Nephi", "9:28-29", "28 O that cunning plan of the evil one! O the vainness, and the frailties, and the foolishness of men! When they are learned they think they are wise, and they hearken not unto the counsel of God, for they set it aside, supposing they know of themselves, wherefore, their wisdom is foolishness and it profiteth them not. And they shall perish. 29 But to be learned is good if they hearken unto the counsels of God." });
        scriptureMasteryPassage.Add(new List<string> { "Doctrine and Covenants", "8:2-3", "2 Yea, behold, I will tell you in your mind and in your heart, by the Holy Ghost, which shall come upon you and which shall dwell in your heart. 3 Now, behold, this is the spirit of revelation; behold, this is the spirit by which Moses brought the children of Israel through the Red Sea on dry ground." });

        // Create a instance of Random to select a random scripture by index
        Random random = new Random();
        int randomIndex = random.Next(scriptureMasteryPassage.Count);
        List<string> selectedScripture = scriptureMasteryPassage[randomIndex];

        // Define order element from Collection
        string book = selectedScripture[0];
        string verses = selectedScripture[1];
        string scriptureText = selectedScripture[2];

        string[] verseParts = verses.Split(':', '-');
        int chapter = int.Parse(verseParts[0]);
        int startVerse = int.Parse(verseParts[1]);
        int endVerse = startVerse;

        if (verseParts.Length > 2)
        {
            endVerse = int.Parse(verseParts[2]);
        }

        Reference reference = new Reference(book, chapter, startVerse, endVerse);
        Scripture scripture = new Scripture(reference, scriptureText);

        Console.Clear();
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetScriptureText());
            Console.WriteLine("Press Enter Key or Type 'quit' for Exit.");
            string inputUser = Console.ReadLine();

            if (inputUser.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
            
        }
        Console.Clear();
        Console.WriteLine("All words its hidden, try to guess or repeat");
    }
}