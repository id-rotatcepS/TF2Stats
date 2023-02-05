using StatsData.GameFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace StatsData
{
    internal class SpreadsheetWriter
    {
        private List<Weapon> weapons;

        public SpreadsheetWriter(List<Weapon> weapons)
        {
            this.weapons = weapons;
        }

        internal async Task Write()
        {
            await WriteSpreadsheetItems();
        }

        private static string spreadsheetText = string.Empty;
        private static StreamWriter spreadsheet;

        private async Task WriteSpreadsheetItems()
        {
            //var fileSavePicker = new Windows.Storage.Pickers.FileSavePicker();
            //fileSavePicker.CommitButtonText = "File to Save spreaedsheet summary";
            //fileSavePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            //fileSavePicker.SuggestedFileName = "spreadsheet.txt";
            //StorageFile file = await fileSavePicker.PickSaveFileAsync();
            //if (file == null) return;
            //using (spreadsheet = new StreamWriter(await file.OpenStreamForWriteAsync()))
            //{
                WriteSpreadsheetItemsHeader();
                //WriteSpreadsheetItemClasses();
                //WriteSpreadsheetPrefabs();
                foreach (Weapon w in weapons)
                {
                    GameItem facts = GameItem.Get(w.ItemsID);
                    WriteSpreadsheetItems(w, facts);
                }

            //    spreadsheet.WriteLine(spreadsheetText);
            //}

            TF2CasualMode.Spreadsheet = spreadsheetText;

        }

        //private void WriteSpreadsheetItemClasses()
        //{
        //    foreach(string filename in ItemClass.AllNames())
        //    {
        //        ItemClass ic = ItemClass.Get(filename);
        //        WriteSpreadsheetItemClass(ic);
        //    }
        //}

        private static void WriteSpreadsheet(string data)
        {
            spreadsheetText += data + "\n";
        }

        private static string GetSpreadsheetItemClassHeader()
        {
            string sep = "\t";
            string header =
                "Item_Class"
                    + sep +
                nameof(ItemClass.PrintName)
                    + sep +
                nameof(ItemClass.BulletsPerShot)
                    + sep +
                nameof(ItemClass.Damage)
                    + sep +
                nameof(ItemClass.Spread)
                    + sep +
                nameof(ItemClass.DamageRadius)
                    + sep +
                nameof(ItemClass.WeaponType)
                    + sep +
                nameof(ItemClass.TimeReload)
                    + sep +
                nameof(ItemClass.TimeReloadStart)
                    + sep +
                nameof(ItemClass.AmmoPerShot)
                    + sep +
                nameof(ItemClass.ClipSize)
                    + sep +
                nameof(ItemClass.DefaultClip)
                    + sep +
                nameof(ItemClass.ProjectileType)
                    + sep +
                nameof(ItemClass.Range)
                    + sep +
                nameof(ItemClass.TimeFireDelay)
                    + sep +
                nameof(ItemClass.TimeIdle)
                    + sep +
                nameof(ItemClass.TimeIdleEmpty)
                    + sep +
                nameof(ItemClass.PunchAngle)
                ;
            return header;
        }
        private void WriteSpreadsheetItemClass(ItemClass ic)
        {
            string row = GetSpreadsheetItemClass(ic);
            WriteSpreadsheet(row);

        }

        private static string GetSpreadsheetItemClass(ItemClass ic)
        {
            string sep = "\t";

            string fileName = ItemClass.GetName(ic);

            string row =
                fileName
                    + sep +
                ic?.PrintName
                    + sep +
                ic?.BulletsPerShot
                    + sep +
                ic?.Damage
                    + sep +
                ic?.Spread
                    + sep +
                ic?.DamageRadius
                    + sep +
                ic?.WeaponType
                    + sep +
                ic?.TimeReload
                    + sep +
                ic?.TimeReloadStart
                    + sep +
                ic?.AmmoPerShot
                    + sep +
                ic?.ClipSize
                    + sep +
                ic?.DefaultClip
                    + sep +
                ic?.ProjectileType
                    + sep +
                ic?.Range
                    + sep +
                ic?.TimeFireDelay
                    + sep +
                ic?.TimeIdle
                    + sep +
                ic?.TimeIdleEmpty
                    + sep +
                ic?.PunchAngle
                ;
            return row;
        }

        private static void WriteSpreadsheetItemsHeader()
        {
            string sep = "\t";

            string header =
                "item id"

                + sep +
                GetSpreadsheetItemClassHeader()

                + sep +
                nameof(GameItem.Name)
                + sep +
                nameof(GameItem.Base_Item_Name)
                + sep +
                nameof(GameItem.Item_Name)
                + sep +
                nameof(GameItem.Item_Quality)
                + sep +
                nameof(GameItem.Item_Slot)
                + sep +
                nameof(GameItem.Item_Type_Name)
                + sep +
                nameof(GameItem.Max_ILevel)
                + sep +
                nameof(GameItem.Min_ILevel)
                + sep +
                nameof(GameItem.First_Sale_Date)
                + sep +
                nameof(GameItem.Xifier_Class_Remap)
                + sep +
                nameof(GameItem.Prefab)
                + sep +
                "tags"
                + sep +
                "attributes"
                + sep +
                "static attribs"
                ;



            WriteSpreadsheet(header);

        }
        private static void WriteSpreadsheetItems(Weapon w, GameItem facts)
        {
            string sep = "\t";
            string row =
                w.ItemsID;

            row += sep +
                GetSpreadsheetItemClass(facts.Item_Class);

            row +=
                sep +
            facts?.Name
            + sep +
            facts?.Base_Item_Name
            + sep +
            facts?.Item_Name
            + sep +
            facts?.Item_Quality
            + sep +
            facts?.Item_Slot
            + sep +
            facts?.Item_Type_Name
            + sep +
            facts?.Max_ILevel
            + sep +
            facts?.Min_ILevel
            + sep +
            facts?.First_Sale_Date
            + sep +
            facts?.Xifier_Class_Remap
            + sep +
            facts?.Prefab;

            row += sep +
                GetSpreadsheetTags(facts?.Tags);

            // these can have key multipliers we need, other stuff is attrs we have only passing interest in.

            // this one has two layers to most attrs (nice name, inside is variable name and value)
            row += sep +
                string.Join(" ; ", facts.Attributes.Select(p => p.Key + ": " + p.Value));
            row += sep +
                string.Join(" ; ", facts.Static_Attrs.Select(p => p.Key + ": " + p.Value));

            WriteSpreadsheet(row);
        }

        private static string GetSpreadsheetTags(Dictionary<string, string> tags)
        {
            //All have values of 1 (assert that's true) - it's just the names bool that matter - list of important tags (or list of unimportant)
            if (tags.Values.Any(s => s != "1")) throw new ArgumentException("unexpected non-1 tag");
            return string.Join(" ; ", tags.Keys);
        }
    }
}