using System.Text;
namespace FirstMVCApp.Models
{
    public class AuthorRepository
    {
        public static Dictionary<int, Author> GetAuthorDictionary()
        {
            String fiName = @"c:\temp\author.txt";
            Dictionary<int, Author> list = new Dictionary<int, Author>();
            bool isFileExists = System.IO.File.Exists(fiName);
            if (isFileExists)
            {
                using (StreamReader sr = new StreamReader(fiName))
                {
                    string strAuthor = $"{sr.ReadLine()}";
                    String[] data = strAuthor.Split(',');
                    Author author = null;
                    if (data.Length == 5)
                    {
                        author = StringToAuthor(data, new Author());
                        list.Add(author.AuthorID, author);
                        while (!sr.EndOfStream)
                        {
                            strAuthor = $"{sr.ReadLine()}";
                            data = strAuthor.Split(",");
                            if (data.Length == 5)
                            {
                                author = StringToAuthor(data, new Author());
                                list.Add(author.AuthorID, author);
                            }
                        }
                    }
                }
            }
            return list;
        }

        private static Author StringToAuthor(String[] data, Author author)
        {
            author.AuthorID = int.Parse(data[0]);
            author.AuthorName = data[1];
            author.AuthorDOB = data[2];
            author.NoOfBooksPublished = int.Parse(data[3]);
            author.RoyaltyCompany = data[4];
            return author;
        }
          public static Author FindAuthorByID(int id)
        {
            Dictionary<int, Author> list = AuthorRepository.GetAuthorDictionary();
            Author author = null;
            if(list != null)
            {
                author = list.FirstOrDefault(x => (x.Key == id)).Value;
            }
            return author;
        }
            public static void SaveToFile(Author pAuthor)
        {
            String fiName = @"c:\temp\author.txt";
            string strAuthor = $"{pAuthor.AuthorID},{pAuthor.AuthorName},{pAuthor.AuthorDOB},{pAuthor.NoOfBooksPublished},{pAuthor.RoyaltyCompany}";
            using (StreamWriter sw = new StreamWriter(fiName,true)) 
            {
                sw.WriteLine(strAuthor);
            }
        }
        public static void UpdateAuthorToFile(Author pAuthor)
        {
            String fiName = @"c:\temp\Author.txt";
            Dictionary<int, Author> list = AuthorRepository.GetAuthorDictionary() ;
            string strAuthor = String.Empty ;
            using (StreamWriter s = new StreamWriter(fiName))
            {
                foreach(Author author in list.Values )
                {
                    if (author.AuthorID != pAuthor.AuthorID)    
                       strAuthor = $"{author.AuthorID},{author.AuthorName},{author.AuthorDOB},{author.NoOfBooksPublished},{author.RoyaltyCompany}";
                    else
                        strAuthor = $"{pAuthor.AuthorID},{pAuthor.AuthorName},{pAuthor.AuthorDOB},{pAuthor.NoOfBooksPublished},{pAuthor.RoyaltyCompany}";
                    s.WriteLine(strAuthor);
                }
            }

        }
          public static void RemoveAuthor(int id)
        {
            String fiName = @"c:\temp\author.txt";
            Dictionary<int, Author> list = AuthorRepository.GetAuthorDictionary() ;
           StringBuilder sbAuthor = new StringBuilder(list.Count + 100) ; 
          
            
                foreach (Author author in list.Values )
                {
                    if (author.AuthorID != id)
                      sbAuthor.Append($"{author.AuthorID},{author.AuthorName},{author.AuthorDOB}," +
                          $"{author.NoOfBooksPublished},{author.RoyaltyCompany}{Environment.NewLine}");
                   
              
                }
            
            File.WriteAllText(fiName, sbAuthor.ToString());
        }
    }
        //public static void SaveAllAuthorsToFile(Dictionary<int, Author> pAuthorList)
        //{
        //    String fiName = @"c:\temo\author.txt";
        //    string strAuthor = $"{pAuthorList.Id},{pAuthorList.Name},{pAuthorList.RoyaltyEarned}"
        //}


    }

