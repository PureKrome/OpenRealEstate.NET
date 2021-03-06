﻿using System;
using Shouldly;
using Xunit;

namespace OpenRealEstate.Tests.Models
{
    public class ResidentialListingTests
    {
        public class CopyTests
        {
            [Fact]
            public void GivenAnExistingListingAndANewListingWithEverythingModified_Copy_CopiesOverTheData()
            {
                // Arrange.
                var sourceListing = TestHelperUtilities.ResidentialListing(false);
                sourceListing.Pricing.SoldPrice = 100;
                sourceListing.Pricing.SoldPriceText = "yah!";
                sourceListing.Pricing.SoldOn = DateTime.Now;

                var destinationListing = TestHelperUtilities.ResidentialListingFromFile();

                // Act.
                destinationListing.Copy(sourceListing);

                // Assert.
                destinationListing.AuctionOn.ShouldBe(sourceListing.AuctionOn);
                destinationListing.CouncilRates.ShouldBe(sourceListing.CouncilRates);
                destinationListing.PropertyType.ShouldBe(sourceListing.PropertyType);

                destinationListing.BuildingDetails.Area.Type.ShouldBe(sourceListing.BuildingDetails.Area.Type);
                destinationListing.BuildingDetails.Area.Value.ShouldBe(sourceListing.BuildingDetails.Area.Value);
                destinationListing.BuildingDetails.EnergyRating.ShouldBe(sourceListing.BuildingDetails.EnergyRating);

                destinationListing.Pricing.SalePrice.ShouldBe(sourceListing.Pricing.SalePrice);
                destinationListing.Pricing.SalePriceText.ShouldBe(sourceListing.Pricing.SalePriceText);
                destinationListing.Pricing.IsUnderOffer.ShouldBe(sourceListing.Pricing.IsUnderOffer);
                destinationListing.Pricing.SoldOn.ShouldBe(sourceListing.Pricing.SoldOn);
                destinationListing.Pricing.SoldPrice.ShouldBe(sourceListing.Pricing.SoldPrice);
                destinationListing.Pricing.SoldPriceText.ShouldBe(sourceListing.Pricing.SoldPriceText);
            }

            [Fact]
            public void GivenAnExistingListingAndANewListingWithANullValues_Copy_CopiesOverTheData()
            {
                // Arrange.
                var sourceListing = TestHelperUtilities.ResidentialListingFromFile();
                sourceListing.BuildingDetails = null;
                sourceListing.Pricing = null;

                var destinationListing = TestHelperUtilities.ResidentialListingFromFile();

                // Act.
                destinationListing.Copy(sourceListing);

                // Assert.
                destinationListing.BuildingDetails.ShouldBeNull();
                destinationListing.Pricing.ShouldBeNull();
            }
        }

        public class ClearAllIsModifiedTests
        {
            [Fact]
            public void GivenAnExistingFullListing_ClearAllIsModified_SetsIsModifiedToFalse()
            {
                // Arrange.
                var listing = TestHelperUtilities.ResidentialListingFromFile(false);

                // Act.
                listing.ClearAllIsModified();

                // Arrange.
                TestHelperUtilities.AssertResidentialListingIsModified(listing, false);
            }
        }
    }
}