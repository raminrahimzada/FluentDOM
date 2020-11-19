namespace FluentDOM
{
    public class EventModel
    {
        public bool? IsPublic { get; set; }
        public bool? IsPartial { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsInternal { get; set; }
        public bool? IsProtected { get; set; }
        public bool? IsAbstract { get; set; }
        public bool? IsSealed { get; set; }
        public bool? IsStatic { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }

        public EventModel Public()
        {
            IsPublic = true;
            return this;
        }
        public EventModel Private()
        {
            IsPrivate = true;
            return this;
        }
        public EventModel Partial()
        {
            IsPartial = true;
            return this;
        }
        public EventModel Protected()
        {
            IsProtected = true;
            return this;
        }
        public EventModel Internal()
        {
            IsInternal = true;
            return this;
        }

        public EventModel Name(string name)
        {
            EventName = name;
            return this;
        }

        
        public EventModel Type(string type)
        {
            EventType = type;
            return this;
        }


        public EventModel Static()
        {
            IsStatic = true;
            return this;
        }

        public EventModel Sealed()
        {
            IsSealed = true;
            return this;
        }

        public EventModel Abstract()
        {
            IsAbstract = true;
            return this;
        }
    }
}