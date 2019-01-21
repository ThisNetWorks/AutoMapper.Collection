using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.EquivalencyExpression;
using FluentAssertions;
using Xunit;

namespace AutoMapper.Collection.Test1
{
    public class MapCollectionWithEqualityTests1
    {
        public MapCollectionWithEqualityTests1()
        {
        }
        
        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently1()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach(var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach(var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently2()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently3()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently4()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently5()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently6()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently7()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently8()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently9()
        {

            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto, Thing>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto, ThingChild>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto, ThingChildChild>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {

                await Task.Run(async () =>
                {
                    var items = new List<Thing>
                        {
                            new Thing (),
                            new Thing (),
                        };

                    var dtos = new List<ThingDto>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing>();
                    foreach (var item in items)
                    {
                        backupItems.Add(item);
                    }
                    mapper.Map(dtos, items).Should().BeSameAs(items);
                    foreach (var item in items)
                    {
                        var backupItem = backupItems.FirstOrDefault(x => x.Id == item.Id);
                        var same = Object.ReferenceEquals(item, backupItem);
                        same.Should().BeTrue();
                        foreach (var child in item.ThingChildren)
                        {
                            var backupChild = backupItem.ThingChildren.FirstOrDefault(x => x.Id == child.Id);
                            var same2 = Object.ReferenceEquals(child, backupChild);
                            same2.Should().BeTrue();
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var backupChildChild = backupChild.ThingChildChildren.FirstOrDefault(x => x.Id == childChild.Id);
                                var same3 = Object.ReferenceEquals(childChild, backupChildChild);
                                same3.Should().BeTrue();
                            }
                        }
                    }

                    return await Task.FromResult(0);
                });
            }
        }




        public class Thing
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChild> ThingChildren = new List<ThingChild>();

            public Thing()
            {
                Id = Guid.NewGuid().ToString();
                ThingChildren = new List<ThingChild>()
                                {
                                    new ThingChild(),
                                    new ThingChild(),
                                    new ThingChild(),
                                    new ThingChild(),
                                    new ThingChild()
                                };
            }
        }

        public class ThingChild
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChildChild> ThingChildChildren = new List<ThingChildChild>();
            public ThingChild()
            {
                Id = Guid.NewGuid().ToString();
                ThingChildChildren = new List<ThingChildChild>()
                                {
                                    new ThingChildChild(),
                                    new ThingChildChild(),
                                    new ThingChildChild(),
                                    new ThingChildChild(),
                                    new ThingChildChild()
                                };
            }
        }

        public class ThingChildChild
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public ThingChildChild()
            {
                Id = Guid.NewGuid().ToString();
            }
        }

        public class ThingDto
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";

            public IList<ThingChildDto> ThingChildren = new List<ThingChildDto>();

        }

        public class ThingChildDto
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChildChildDto> ThingChildChildren = new List<ThingChildChildDto>();
        }

        public class ThingChildChildDto
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
        }
        
    }
}