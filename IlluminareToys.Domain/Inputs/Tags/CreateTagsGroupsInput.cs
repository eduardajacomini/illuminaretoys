﻿namespace IlluminareToys.Domain.Inputs.Tags
{
    public record CreateTagsGroupsInput
    {
        public IEnumerable<CreateTagGroupInputItem> TagsGroups { get; set; } = new List<CreateTagGroupInputItem>();
    }

    public record CreateTagGroupInputItem
    {
        public Guid TagId { get; set; }

        public Guid GroupId { get; set; }

        public string Age { get; set; }
    }

}