using System;

namespace nothinbutdotnetprep.collections
{
  public class Movie //: IComparable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }
   
      //public int CompareTo(Movie other)
      //{
      //    return
      //        (other.genre.ToString() + other.date_published.ToString() + other.production_studio + other.rating +
      //         other.title).CompareTo(this.genre.ToString() + this.date_published.ToString() + this.production_studio +
      //                                this.rating + this.title);
      //}
  }
}