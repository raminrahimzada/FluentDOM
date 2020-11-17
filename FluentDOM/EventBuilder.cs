namespace FluentDOM
{
    public class EventBuilder
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

        public EventBuilder Public()
        {
            IsPublic = true;
            return this;
        }
        public EventBuilder Private()
        {
            IsPrivate = true;
            return this;
        }
        public EventBuilder Partial()
        {
            IsPartial = true;
            return this;
        }
        public EventBuilder Protected()
        {
            IsProtected = true;
            return this;
        }
        public EventBuilder Internal()
        {
            IsInternal = true;
            return this;
        }

        public EventBuilder Name(string name)
        {
            EventName = name;
            return this;
        }

        
        public EventBuilder Type(string type)
        {
            EventType = type;
            return this;
        }


        public EventBuilder Static()
        {
            IsStatic = true;
            return this;
        }

        public EventBuilder Sealed()
        {
            IsSealed = true;
            return this;
        }

        public EventBuilder Abstract()
        {
            IsAbstract = true;
            return this;
        }
    }
}