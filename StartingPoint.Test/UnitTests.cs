using System;
using NUnit.Framework;

namespace StartingPoint
{
	/// <summary>
	/// Unit tests for StartingPoint project.
	/// </summary>
	[TestFixture]
	public class UnitTests
	{
		/* Fields */

		// Movies
		Movie m_Cinderella;
		Movie m_StarWars;
		Movie m_Gladiator;

		// Rentals
		Rental m_Rental1;
		Rental m_Rental2;
		Rental m_Rental3;

		// Customers
		Customer m_MickeyMouse;
		Customer m_DonaldDuck;
		Customer m_MinnieMouse;

        DateProcessor dateProcessor;

		/* Methods */

		[SetUp]
		public void Init()
		{
			// Create movies
			m_Cinderella = new Movie("Cinderella", PriceCodes.Childrens);
			m_StarWars = new Movie("Star Wars", PriceCodes.Regular);
			m_Gladiator = new Movie("Gladiator", PriceCodes.NewRelease);

			// Create rentals
			m_Rental1 = new Rental(m_Cinderella, 5);
			m_Rental2 = new Rental(m_StarWars, 5);
			m_Rental3 = new Rental(m_Gladiator, 5);

			// Create customers
			m_MickeyMouse = new Customer("Mickey Mouse");
			m_DonaldDuck = new Customer("Donald Duck");
			m_MinnieMouse = new Customer("Minnie Mouse");

            dateProcessor = new DateProcessor();
		}

		[Test]
		public void TestMovie()
		{
			// Test title property
			Assert.That("Cinderella", Is.EqualTo(m_Cinderella.Title));
			Assert.That("Star Wars", Is.EqualTo(m_StarWars.Title));
			Assert.That("Gladiator", Is.EqualTo(m_Gladiator.Title));

			// Test price code
			Assert.That(PriceCodes.Childrens, Is.EqualTo(m_Cinderella.PriceCode));
			Assert.That(PriceCodes.Regular, Is.EqualTo(m_StarWars.PriceCode));
			Assert.That(PriceCodes.NewRelease, Is.EqualTo(m_Gladiator.PriceCode));
		}

		[Test]
		public void TestRental()
		{
			// Test Movie property
			Assert.That(m_Cinderella, Is.EqualTo(m_Rental1.Movie));
			Assert.That(m_StarWars, Is.EqualTo(m_Rental2.Movie));
			Assert.That(m_Gladiator, Is.EqualTo(m_Rental3.Movie));

			// Test DaysRented property
			Assert.That(5, Is.EqualTo(m_Rental1.DaysRented));
			Assert.That(5, Is.EqualTo(m_Rental1.DaysRented));
			Assert.That(5, Is.EqualTo(m_Rental1.DaysRented));
		}

		[Test]
		public void TestCustomer()
		{
			// Test Name property
			Assert.That("Mickey Mouse", Is.EqualTo(m_MickeyMouse.Name));
			Assert.That("Donald Duck", Is.EqualTo(m_DonaldDuck.Name));
			Assert.That("Minnie Mouse", Is.EqualTo(m_MinnieMouse.Name));

			// Test AddRental() method - set up for test
			m_MickeyMouse.AddRental(m_Rental1);
			m_MickeyMouse.AddRental(m_Rental2);
			m_MickeyMouse.AddRental(m_Rental3);

			/* At this point, the structure of the program begins getting in the
			 * way of testing. Rentals are imbedded in the Customer object, but
			 * there is no property to access them. They can only be accessed 
			 * internally, by the Statement() method, which imbeds them in the
			 * text string passed as it's return value. So, to get these amounts,
			 * we will have to parse that value. */

			// Test the Statement() method
			string theResult = m_MickeyMouse.Statement();

			// Parse the result
			char[] delimiters = "\n\t".ToCharArray();
			string[] results = theResult.Split(delimiters);

			/* The results[] array will have the following elements:
			 *		[0] = junk
			 *		[1] = junk
			 *		[2] = title #1
			 *		[3] = price #1
			 *		[4] = junk
			 *		[5] = title #2
			 *		[6] = price #2
			 *		[7] = junk
			 *		[8] = title #3
			 *		[9] = price #3
			 *		[10] = "Amount owed is x"
			 *		[11] = "You earned x frequent renter points."
			 * We will test the title and price elements, and the total 
			 * and frequent renter points items. If these tests pass, then 
			 * we know that AddRentals() is adding rentals to a Customer 
			 * object properly, and that the Statement() method is
			 * generating a statement in the expected format. */

			// Test the title and price items
			Assert.That("Cinderella", Is.EqualTo(results[2]));
			Assert.That(3, Is.EqualTo(Convert.ToDouble(results[3])));
			Assert.That("Star Wars", Is.EqualTo(results[5]));
			Assert.That(6.5, Is.EqualTo(Convert.ToDouble(results[6])));
			Assert.That("Gladiator", Is.EqualTo(results[8]));
			Assert.That(15, Is.EqualTo(Convert.ToDouble(results[9])));
		}

        [Test]
        public void TestDateProcessor
        {
            
        }

	}
}
