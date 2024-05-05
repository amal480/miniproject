using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniproject
{
    public class Datamodel
    {

        
            public Content[] content { get; set; }
            public Pageable pageable { get; set; }
            public int totalPages { get; set; }
            public int totalElements { get; set; }
            public bool last { get; set; }
            public int number { get; set; }
            public Sort1 sort { get; set; }
            public int size { get; set; }
            public bool first { get; set; }
            public int numberOfElements { get; set; }
            public bool empty { get; set; }
        

        public class Pageable
        {
            public Sort sort { get; set; }
            public int offset { get; set; }
            public int pageNumber { get; set; }
            public int pageSize { get; set; }
            public bool paged { get; set; }
            public bool unpaged { get; set; }
        }

        public class Sort
        {
            public bool sorted { get; set; }
            public bool unsorted { get; set; }
            public bool empty { get; set; }
        }

        public class Sort1
        {
            public bool sorted { get; set; }
            public bool unsorted { get; set; }
            public bool empty { get; set; }
        }

        public class Content
        {
            public int id { get; set; }
            public string announcementDate { get; set; }
            public string subject { get; set; }
            public object urlHref { get; set; }
            public object urlTitle { get; set; }
            public string message { get; set; }
            public object fromDate { get; set; }
            public object toDate { get; set; }
            public object showInHomePage { get; set; }
            public int status { get; set; }
            public Attachmentlist[] attachmentList { get; set; }
        }

        public class Attachmentlist
        {
            public object createdDate { get; set; }
            public object createdBy { get; set; }
            public object modifiedDate { get; set; }
            public object modifiedBy { get; set; }
            public bool setModifiedDetails { get; set; }
            public int id { get; set; }
            public int entityId { get; set; }
            public object documentTypeId { get; set; }
            public object typeId { get; set; }
            public string title { get; set; }
            public string attachmentName { get; set; }
            public object size { get; set; }
            public object mimeTypeId { get; set; }
            public object comments { get; set; }
            public object dataBytes { get; set; }
            public string encryptId { get; set; }
        }

    }
}
