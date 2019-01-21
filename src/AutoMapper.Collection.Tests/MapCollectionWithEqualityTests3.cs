using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.EquivalencyExpression;
using FluentAssertions;
using Xunit;

namespace AutoMapper.Collection.Test3
{
    public class MapCollectionWithEqualityTests3
    {
        public MapCollectionWithEqualityTests3()
        {
        }

        [Fact]
        public async Task Should_Keep_Existing_List_Concurrently1()
        {
            var configuration = new MapperConfiguration(x =>
            {
                x.AddCollectionMappers();
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos =new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos = new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos = new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos = new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos = new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos = new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos = new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos = new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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
                x.CreateMap<ThingDto3, Thing3>()
                    .ForMember(dest => dest.ThingChildren, opts => opts.MapFrom(src => src.ThingChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildDto3, ThingChild3>()
                    .ForMember(dest => dest.ThingChildChildren, opts => opts.MapFrom(src => src.ThingChildChildren))
                    .EqualityComparison((src, dest) => src.Id == dest.Id);

                x.CreateMap<ThingChildChildDto3, ThingChildChild3>()
                    .EqualityComparison((src, dest) => src.Id == dest.Id);
            }
            );
            IMapper mapper = new Mapper(configuration);
            for (var i = 0; i < 10000; i++)
            {
                await Task.Run(async () =>
                {
                    var items = new List<Thing3>
                        {
                            new Thing3 (),
                            new Thing3 (),
                        };

                    var dtos = new List<ThingDto3>();
                    foreach (var item in items)
                    {
                        var dto = new ThingDto3() { Id = item.Id };
                        foreach (var child in item.ThingChildren)
                        {
                            var dtoChild = new ThingChildDto3() { Id = child.Id };
                            foreach (var childChild in child.ThingChildChildren)
                            {
                                var dtoChildChild = new ThingChildChildDto3() { Id = childChild.Id };
                                dtoChild.ThingChildChildren.Add(dtoChildChild);
                            }
                            dto.ThingChildren.Add(dtoChild);
                        }
                        dtos.Add(dto);
                    }

                    var backupItems = new List<Thing3>();
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



        public class Thing3
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChild3> ThingChildren = new List<ThingChild3>();

            public Thing3()
            {
                Id = Guid.NewGuid().ToString();
                ThingChildren = new List<ThingChild3>()
                                {
                                    new ThingChild3(),
                                    new ThingChild3(),
                                    new ThingChild3(),
                                    new ThingChild3(),
                                    new ThingChild3()
                                };
            }
        }

        public class ThingChild3
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChildChild3> ThingChildChildren = new List<ThingChildChild3>();
            public ThingChild3()
            {
                Id = Guid.NewGuid().ToString();
                ThingChildChildren = new List<ThingChildChild3>()
                                {
                                    new ThingChildChild3(),
                                    new ThingChildChild3(),
                                    new ThingChildChild3(),
                                    new ThingChildChild3(),
                                    new ThingChildChild3()
                                };
            }
        }

        public class ThingChildChild3
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public ThingChildChild3()
            {
                Id = Guid.NewGuid().ToString();
            }
        }

        public class ThingDto3
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";

            public IList<ThingChildDto3> ThingChildren = new List<ThingChildDto3>();

        }

        public class ThingChildDto3
        {
            public string Id { get; set; }
            public string Stuff { get; set; } = "stuff";
            public string Stuff2 { get; set; } = "stuff";
            public string Stuff3 { get; set; } = "stuff";
            public string Stuff4 { get; set; } = "stuff";
            public string Stuff5 { get; set; } = "stuff";
            public string Stuff6 { get; set; } = "stuff";
            public IList<ThingChildChildDto3> ThingChildChildren = new List<ThingChildChildDto3>();
        }

        public class ThingChildChildDto3
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