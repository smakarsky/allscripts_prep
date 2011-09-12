using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (movies.Contains(movie)) return;

            this.movies.Add(movie);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return all_movies_matching(movie => movie.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return all_movies_matching(m => m.production_studio == ProductionStudio.Pixar ||
                m.production_studio == ProductionStudio.Disney);
        }

        public IEnumerable<Movie> all_movies_matching(Predicate<Movie> criteria)
        {
            return movies.all_items_matching(new AnonymousMatch<Movie>(criteria));
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return all_movies_matching(m => m.production_studio != ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_matching(m => m.date_published.Year > year);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.kids)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.action)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            //return ((List<Movie>) movies).Sort();
            throw new NotImplementedException();
        }
    }
}