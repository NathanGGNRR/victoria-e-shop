//-----------------------------------------------------------------------
// <copyright file="MappingTests.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.UnitTests.Commun.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Mappings;
    using AutoMapper;
    using Domain.Entities;
    using NUnit.Framework;

    /// <summary>
    /// Test class for the mapping.
    /// </summary>
    public class MappingTests
    {
        /// <summary>
        /// The interface of the configuration provider.
        /// </summary>
        private readonly IConfigurationProvider configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingTests"/> class.
        /// </summary>
        public MappingTests()
        {
            this.configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }

        /// <summary>
        /// Test to check if the configuration is valid.
        /// </summary>
        [Test]
        public void ShouldHaveValidConfiguration()
        {
            this.configuration.AssertConfigurationIsValid();
        }
    }
}