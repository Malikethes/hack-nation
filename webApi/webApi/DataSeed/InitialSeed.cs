using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.DataSeed
{
    public static class InitialSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                // Row 1: 1,11-02-1980,1,2.2,ala,10:10,11-02-1980 13:13:31,,1,True,
                new Item
                {
                    Id = 1,
                    Data = "11-02-1980",
                    Int = 1,
                    Float = 2.2f,
                    Mieszane = "ala",
                    Czas = "10:10",
                    Dataczas = "11-02-1980 13:13:31",
                    Pusta = null,
                    Mieszane2 = "1",
                    Boolean = true,
                    DuzoMissingowInt = null
                },

                // Row 2: 2,,1,2.2,,10:10,,,1.1,False,
                new Item
                {
                    Id = 2,
                    Data = null,
                    Int = 1,
                    Float = 2.2f,
                    Mieszane = null,
                    Czas = "10:10",
                    Dataczas = null,
                    Pusta = null,
                    Mieszane2 = "1.1",
                    Boolean = false,
                    DuzoMissingowInt = null
                },

                // Row 3: 3,11-02-1980,,,kot,10:10,11-02-1980 13:13:31,,x,,
                // CLEANUP: Int, Float, Boolean are required but missing. Used defaults: 0, 0.0f, false.
                new Item
                {
                    Id = 3,
                    Data = "11-02-1980",
                    Int = 0,
                    Float = 0.0f,
                    Mieszane = "kot",
                    Czas = "10:10",
                    Dataczas = "11-02-1980 13:13:31",
                    Pusta = null,
                    Mieszane2 = "x",
                    Boolean = false,
                    DuzoMissingowInt = null
                },

                // Row 4: ,11-02-1980,,2.2,1,,11-02-1980 13:13:31,,10:10,,
                // CLEANUP: Missing ID -> Assigned 4. Missing Int/Bool -> Assigned 0/False.
                new Item
                {
                    Id = 4,
                    Data = "11-02-1980",
                    Int = 0,
                    Float = 2.2f,
                    Mieszane = "1",
                    Czas = null,
                    Dataczas = "11-02-1980 13:13:31",
                    Pusta = null,
                    Mieszane2 = "10:10",
                    Boolean = false,
                    DuzoMissingowInt = null
                },

                // Row 5: 5,,1,2.2,2,,11-02-1980 13:13:31,,12-01-2020 10:10,True,
                new Item
                {
                    Id = 5,
                    Data = null,
                    Int = 1,
                    Float = 2.2f,
                    Mieszane = "2",
                    Czas = null,
                    Dataczas = "11-02-1980 13:13:31",
                    Pusta = null,
                    Mieszane2 = "12-01-2020 10:10",
                    Boolean = true,
                    DuzoMissingowInt = null
                },

                // Row 6: 6,11-02-1980,1,2.2,3,10:10,11-02-1980 13:13:31,,12-12-2020,False,
                new Item
                {
                    Id = 6,
                    Data = "11-02-1980",
                    Int = 1,
                    Float = 2.2f,
                    Mieszane = "3",
                    Czas = "10:10",
                    Dataczas = "11-02-1980 13:13:31",
                    Pusta = null,
                    Mieszane2 = "12-12-2020",
                    Boolean = false,
                    DuzoMissingowInt = null
                },

                // Row 7: 7,11-02-1980,1,,4,10:10,,,,,
                // CLEANUP: Missing Float -> Assigned 0.0f. Missing Bool -> False.
                new Item
                {
                    Id = 7,
                    Data = "11-02-1980",
                    Int = 1,
                    Float = 0.0f,
                    Mieszane = "4",
                    Czas = "10:10",
                    Dataczas = null,
                    Pusta = null,
                    Mieszane2 = null,
                    Boolean = false,
                    DuzoMissingowInt = null
                },

                // Row 8: ,11-02-1980,1,2.2,5,10:10,11-02-1980 13:13:31,,True,True,1
                // CLEANUP: Missing ID -> Assigned 8.
                new Item
                {
                    Id = 8,
                    Data = "11-02-1980",
                    Int = 1,
                    Float = 2.2f,
                    Mieszane = "5",
                    Czas = "10:10",
                    Dataczas = "11-02-1980 13:13:31",
                    Pusta = null,
                    Mieszane2 = "True",
                    Boolean = true,
                    DuzoMissingowInt = 1
                }
            );
        }
    }
}
