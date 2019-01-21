using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.EquivalencyExpression;
using FluentAssertions;
using Xunit;


namespace AutoMapper.Collection.Test2
{
    public class MapCollectionWithEqualityTests2
    {
        public MapCollectionWithEqualityTests2()
        {
        }



        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently1()
        {
            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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
                x.CreateMap<ThingDto2, Thing2>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto2, ThingChild2>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto2, ThingChildChild2>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing2>
                        {
                            new Thing2 (),
                            new Thing2 (),
                        };

                    var dtos = new List<ThingDto2>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto2() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto2() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto2() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing2>();
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

        public class Thing2
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChild2> ThingChildren = new List<ThingChild2>();

            public Thing2()
            {
                Id = Guid.NewGuid().ToString();
                ThingChildren = new List<ThingChild2>()
                                {
                                    new ThingChild2(),
                                    new ThingChild2(),
                                    new ThingChild2(),
                                    new ThingChild2(),
                                    new ThingChild2()
                                };
            }
        }

        public class ThingChild2
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChildChild2> ThingChildChildren = new List<ThingChildChild2>();
            public ThingChild2()
            {
                Id = Guid.NewGuid().ToString();
                ThingChildChildren = new List<ThingChildChild2>()
                                {
                                    new ThingChildChild2(),
                                    new ThingChildChild2(),
                                    new ThingChildChild2(),
                                    new ThingChildChild2(),
                                    new ThingChildChild2()
                                };
            }
        }

        public class ThingChildChild2
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public ThingChildChild2()
            {
                Id = Guid.NewGuid().ToString();
            }
        }

        public class ThingDto2
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";

            public IList<ThingChildDto2> ThingChildren = new List<ThingChildDto2>();

        }

        public class ThingChildDto2
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChildChildDto2> ThingChildChildren = new List<ThingChildChildDto2>();
        }

        public class ThingChildChildDto2
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