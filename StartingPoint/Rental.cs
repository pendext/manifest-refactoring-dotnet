using System;

namespace StartingPoint
{
	/// <summary>
	/// Rental represents a customer renting a movie.
	/// </summary>
	public class Rental
	{
		/* Fields */

		// Data members
		private Movie m_Movie;
		private int m_DaysRented;

		/* Constructor */

		public Rental(Movie movie, int daysRented)
		{
			m_Movie = movie;
			m_DaysRented = daysRented;
		}

		/* Properties */

		public int DaysRented
		{
			get {return m_DaysRented;}
		}

		public Movie Movie
		{
			get {return m_Movie;}
		}
	}
}
