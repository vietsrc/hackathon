using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Generated from http://json2csharp.com/ based on this json http://services.radio-canada.ca/neuro/v1/future/lineups/1000197
/// </summary>
namespace RCBot.Helpers.DTO.LineUp
{
    public class SelfLink
    {
        public string href { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class FirstPageLink
    {
        public string href { get; set; }
    }

    public class NextPageLink
    {
        public string href { get; set; }
    }

    public class LastPageLink
    {
        public string href { get; set; }
    }

    public class SelfLink2
    {
        public string href { get; set; }
    }

    public class CanonicalWebLink
    {
        public string href { get; set; }
    }

    public class ContentType
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class PrimaryClassificationTag
    {
        public string id { get; set; }
        public string name { get; set; }
        public string codeName { get; set; }
    }

    public class ThemeTag
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Category2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class CustomTag
    {
        public Category2 category { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class ContentType2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class MediaLink
    {
        public string href { get; set; }
    }

    public class ConcreteImage
    {
        public MediaLink mediaLink { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string dimensionRatio { get; set; }
    }

    public class SummaryMultimediaItem
    {
        public ContentType2 contentType { get; set; }
        public string alt { get; set; }
        public string legend { get; set; }
        public string imageCredits { get; set; }
        public List<object> pressAgencies { get; set; }
        public string imageCollection { get; set; }
        public List<ConcreteImage> concreteImages { get; set; }
    }

    public class ContentTypeClassificationTag
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Item
    {
        public SelfLink2 selfLink { get; set; }
        public CanonicalWebLink canonicalWebLink { get; set; }
        public ContentType contentType { get; set; }
        public string id { get; set; }
        public PrimaryClassificationTag primaryClassificationTag { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string kicker { get; set; }
        public string futurePublishedLastTimeAt { get; set; }
        public object template { get; set; }
        public ThemeTag themeTag { get; set; }
        public List<object> subThemeTags { get; set; }
        public List<object> regionTags { get; set; }
        public bool isOfRegionalInterestOnly { get; set; }
        public List<object> subjectTags { get; set; }
        public List<CustomTag> customTags { get; set; }
        public object sector { get; set; }
        public object subSector { get; set; }
        public object broadcastableItem { get; set; }
        public List<object> signatures { get; set; }
        public object referredContent { get; set; }
        public SummaryMultimediaItem summaryMultimediaItem { get; set; }
        public List<object> relatedContents { get; set; }
        public ContentTypeClassificationTag contentTypeClassificationTag { get; set; }
        public string publishedLastTimeAt { get; set; }
    }

    public class PagedList
    {
        public FirstPageLink firstPageLink { get; set; }
        public object previousPageLink { get; set; }
        public NextPageLink nextPageLink { get; set; }
        public LastPageLink lastPageLink { get; set; }
        public int totalNumOfItems { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public List<Item> items { get; set; }
    }

    public class LineUp
    {
        public SelfLink selfLink { get; set; }
        public object stickyLineupLink { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public object template { get; set; }
        public Category category { get; set; }
        public PagedList pagedList { get; set; }
    }
}