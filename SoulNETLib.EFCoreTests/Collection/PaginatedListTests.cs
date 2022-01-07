﻿using FluentAssertions;
using SoulNETLib.EFCore.Collection;
using SoulNETLib.Extension;
using SoulNETLibTests.Common.TestData.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;

namespace SoulNETLib.EFCoreTests.Collection
{
    public class PaginatedListTests
    {
        private readonly string _pathToCommonTestFiles = "..\\..\\..\\..\\SoulNETLibTests.Common\\TestData\\Files\\";

        [Fact]
        public void PaginatedList_InitializedList_ReturnJsonList()
        {
            // Arrange
            var items = new List<SampleObject>()
            {
                new SampleObject("name1") {Id =1, Comment = "comment1"},
                new SampleObject("name2") {Id =2, Comment = "comment2"},
                new SampleObject("name3") {Id =3, Comment = "comment3"},
                new SampleObject("name4") {Id =4, Comment = "comment4"},
                new SampleObject("name5") {Id =5, Comment = "comment5"}
            };
            var list = new PaginatedList<SampleObject>(items, 123123, 2, 5);

            // Act
            string jsonString = JsonSerializer.Serialize(list).RemoveWhitespaces();

            // Assert
            jsonString.Should().Be("[{\"Id\":1,\"Name\":\"name1\",\"Comment\":\"comment1\",\"DateTime\":\"0001-01-01T00:00:00\"},{\"Id\":2,\"Name\":\"name2\",\"Comment\":\"comment2\",\"DateTime\":\"0001-01-01T00:00:00\"},{\"Id\":3,\"Name\":\"name3\",\"Comment\":\"comment3\",\"DateTime\":\"0001-01-01T00:00:00\"},{\"Id\":4,\"Name\":\"name4\",\"Comment\":\"comment4\",\"DateTime\":\"0001-01-01T00:00:00\"},{\"Id\":5,\"Name\":\"name5\",\"Comment\":\"comment5\",\"DateTime\":\"0001-01-01T00:00:00\"}]");
        }

        [Fact]
        public void PaginatedList_InitializedList_MatchJsonSample()
        {
            // Arrange
            var items = new List<SampleObject>()
            {
                new SampleObject("name1") {Id =1, Comment = "comment1"},
                new SampleObject("name2") {Id =2, Comment = "comment2"},
                new SampleObject("name3") {Id =3, Comment = "comment3"},
                new SampleObject("name4") {Id =4, Comment = "comment4"},
                new SampleObject("name5") {Id =5, Comment = "comment5"}
            };
            var list = new PaginatedList<SampleObject>(items, 123123, 2, 5);

            // Act
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(list, options);
            string contents = File.ReadAllText(_pathToCommonTestFiles + "PaginatedListSample.json");

            // Assert
            jsonString.Should().Be(contents);
        }

        [Fact]
        public void PaginatedResult_InitializedList_ReturnJsonResult()
        {
            // Arrange
            var items = new List<SampleObject>()
            {
                new SampleObject("name1") {Id =1, Comment = "comment1"},
                new SampleObject("name2") {Id =2, Comment = "comment2"},
                new SampleObject("name3") {Id =3, Comment = "comment3"},
                new SampleObject("name4") {Id =4, Comment = "comment4"},
                new SampleObject("name5") {Id =5, Comment = "comment5"}
            };
            var list = new PaginatedResult<SampleObject>(new PaginatedList<SampleObject>(items, 123123, 2, 5));

            // Act
            string jsonString = JsonSerializer.Serialize(list).RemoveWhitespaces();

            // Assert
            jsonString.Should().Be("{\"page\":2,\"size\":5,\"pages\":24625,\"rows\":123123,\"items\":[{\"Id\":1,\"Name\":\"name1\",\"Comment\":\"comment1\",\"DateTime\":\"0001-01-01T00:00:00\"},{\"Id\":2,\"Name\":\"name2\",\"Comment\":\"comment2\",\"DateTime\":\"0001-01-01T00:00:00\"},{\"Id\":3,\"Name\":\"name3\",\"Comment\":\"comment3\",\"DateTime\":\"0001-01-01T00:00:00\"},{\"Id\":4,\"Name\":\"name4\",\"Comment\":\"comment4\",\"DateTime\":\"0001-01-01T00:00:00\"},{\"Id\":5,\"Name\":\"name5\",\"Comment\":\"comment5\",\"DateTime\":\"0001-01-01T00:00:00\"}]}");
        
        }

        [Fact]
        public void PaginatedResult_InitializedList_MatchJsonSample()
        {
            // Arrange
            var items = new List<SampleObject>()
            {
                new SampleObject("name1") {Id =1, Comment = "comment1"},
                new SampleObject("name2") {Id =2, Comment = "comment2"},
                new SampleObject("name3") {Id =3, Comment = "comment3"},
                new SampleObject("name4") {Id =4, Comment = "comment4"},
                new SampleObject("name5") {Id =5, Comment = "comment5"}
            };
            var list = new PaginatedResult<SampleObject>(new PaginatedList<SampleObject>(items, 123123, 2, 5));

            // Act
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(list, options);
            string contents = File.ReadAllText(_pathToCommonTestFiles + "PaginatedResultSample.json");

            // Assert
            jsonString.Should().Be(contents);
        }
    }
}
