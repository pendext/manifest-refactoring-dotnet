using System;


namespace StartingPoint
{
	/// <summary>
	/// Price codes
	/// </summary>
	public enum PriceCodes
	{
		Regular,
		NewRelease,
		Childrens
	}
	/// <summary>
	/// Movie is just a simple data class.
	/// </summary>
	public class Movie
	{
		/* Fields */

		// Price code constants changed to enum

		// Data members
		private string m_Title;
		private PriceCodes m_PriceCode;

		/* Constructor */

		public Movie(string title, PriceCodes priceCode)
		{
			m_Title = title;
			m_PriceCode = priceCode;
		}

		/* Properties */

		public PriceCodes PriceCode
		{
			get {return m_PriceCode;}
			set {m_PriceCode = value;}
		}

		public string Title
		{
			get {return m_Title;}
		}
	}
}
