using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net;
using System.Diagnostics;
using DevComponents.DotNetBar;

namespace Minecraft_Toolkit
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if(txtX1.Text == "" || txtY1.Text == "" || txtZ1.Text == "")
            {
                MessageBox.Show("You need to fill out the overworld coords boxs!", "Error!!");
            }else{
                int x, y, z;
                x = Convert.ToInt32(txtX1.Text);
                y = Convert.ToInt32(txtY1.Text);
                z = Convert.ToInt32(txtZ1.Text);

                x = x / 8;
                y = y / 8;
                z = z / 8;

                txtXOutput1.Text = (x.ToString());
                txtYOutput1.Text = (y.ToString());
                txtZOutput1.Text = (z.ToString());
            }
        }

        private void btnCalculate2_Click(object sender, EventArgs e)
        {
            if (txtX2.Text == "" || txtY2.Text == "" || txtZ2.Text == "")
            {
                MessageBox.Show("You need to fill out the overworld coords boxs!", "Error!!");
            }
            else
            {
                int x, y, z;
                x = Convert.ToInt32(txtX2.Text);
                y = Convert.ToInt32(txtY2.Text);
                z = Convert.ToInt32(txtZ2.Text);

                x = x * 8;
                y = y * 8;
                z = z * 8;

                txtXOutput2.Text = (x.ToString());
                txtYOutput2.Text = (y.ToString());
                txtZOutput2.Text = (z.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(updatestab);
            if(!Directory.Exists(Application.StartupPath + "/textures")){
                DialogResult dialogResult = MessageBox.Show("You need the textures folder in the same place as the exe file!", "Error!", MessageBoxButtons.OK);
                if(dialogResult == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

            Checkforupdate();

            RecipeSelector.Items.Add("Redstone Repeater");
            RecipeSelector.Items.Add("Redstone Lamp");
            RecipeSelector.Items.Add("Redstone Compartor");
            RecipeSelector.Items.Add("Dispenser");
            RecipeSelector.Items.Add("Dropper");

            RecipeSelector.Items.Add("Powered Rail");
            RecipeSelector.Items.Add("Rail");

            RecipeSelector.Items.Add("Piston");
            RecipeSelector.Items.Add("Sticky Piston");
            RecipeSelector.Items.Add("Hopper");
            RecipeSelector.Items.Add("Door (Any wood)");
            RecipeSelector.Items.Add("Iron Door");
            RecipeSelector.Items.Add("Fence Gate (Any wood)");
            RecipeSelector.Items.Add("Fence (Any wood)(1.7.0 and earlier)");
            RecipeSelector.Items.Add("Fence (Any wood)(1.8+)");
            RecipeSelector.Items.Add("Bow");
            RecipeSelector.Items.Add("Fishing Rod");
            RecipeSelector.Items.Add("Lever");
            RecipeSelector.Items.Add("Tnt");
            RecipeSelector.Items.Add("Bookshelf");
            RecipeSelector.Items.Add("Beacon");
            RecipeSelector.Items.Add("Enchantment Table");
            RecipeSelector.Items.Add("Brewing Stand");

            RecipeSelector.Items.Add("Wood Pickaxe");
            RecipeSelector.Items.Add("Wood Axe");
            RecipeSelector.Items.Add("Wood Hoe");
            RecipeSelector.Items.Add("Wood Shovel");
            RecipeSelector.Items.Add("Wood Sword");

            RecipeSelector.Items.Add("Stone Pickaxe");
            RecipeSelector.Items.Add("Stone Axe");
            RecipeSelector.Items.Add("Stone Hoe");
            RecipeSelector.Items.Add("Stone Shovel");
            RecipeSelector.Items.Add("Stone Sword");

            RecipeSelector.Items.Add("Iron Pickaxe");
            RecipeSelector.Items.Add("Iron Axe");
            RecipeSelector.Items.Add("Iron Hoe");
            RecipeSelector.Items.Add("Iron Shovel");
            RecipeSelector.Items.Add("Iron Sword");

            RecipeSelector.Items.Add("Golden Pickaxe");
            RecipeSelector.Items.Add("Golden Axe");
            RecipeSelector.Items.Add("Golden Hoe");
            RecipeSelector.Items.Add("Golden Shovel");
            RecipeSelector.Items.Add("Golden Sword");

            RecipeSelector.Items.Add("Diamond Pickaxe");
            RecipeSelector.Items.Add("Diamond Axe");
            RecipeSelector.Items.Add("Diamond Hoe");
            RecipeSelector.Items.Add("Diamond Shovel");
            RecipeSelector.Items.Add("Diamond Sword");

            RecipeSelector.Items.Add("Block of Gold");
            RecipeSelector.Items.Add("Block of Coal");
            RecipeSelector.Items.Add("Block of Iron");
            RecipeSelector.Items.Add("Block of Diamond");
            RecipeSelector.Items.Add("Block of Emerald");
            RecipeSelector.Items.Add("Block of Quartz");
            RecipeSelector.Items.Add("Block of Redstone");
            RecipeSelector.Items.Add("Block of Lapis");

            RecipeSelector.Items.Add("Stone Button");
            RecipeSelector.Items.Add("Wooden Button");
            RecipeSelector.Items.Add("Note Block");
            RecipeSelector.Items.Add("Stone Pressure Plate");
            RecipeSelector.Items.Add("Wooden Pressure Plate");
            RecipeSelector.Items.Add("Redstone");
            RecipeSelector.Items.Add("Gold Ingot");
            RecipeSelector.Items.Add("Iron Ingot");
            RecipeSelector.Items.Add("Coal");
            RecipeSelector.Items.Add("Diamond");
            RecipeSelector.Items.Add("Emerald");
            RecipeSelector.Items.Add("Lapis");
            RecipeSelector.Items.Add("Bed");
            RecipeSelector.Items.Add("Stone Bricks");

            RecipeSelector.Items.Add("Wood Slab(Any wood)");
            RecipeSelector.Items.Add("Nether Brick Slab");
            RecipeSelector.Items.Add("Stone Bricks Slab(Any Stone Bricks)");
            RecipeSelector.Items.Add("Bricks Slab");
            RecipeSelector.Items.Add("Cobblestone Slab");
            RecipeSelector.Items.Add("Sandstone Slab(Any Sandstone)");
            RecipeSelector.Items.Add("Stone Slab");
            RecipeSelector.Items.Add("Quartz Slab(Any Quartz Block)");
            RecipeSelector.Items.Add("Red Sandstone Slab(Any Red Sandstone)");

            RecipeSelector.Items.Add("Wood Stairs(Any wood)");
            RecipeSelector.Items.Add("Nether Brick Stairs");
            RecipeSelector.Items.Add("Stone Bricks Stairs(Any Stone Bricks)");
            RecipeSelector.Items.Add("Bricks Stairs");
            RecipeSelector.Items.Add("Cobblestone Stairs");
            RecipeSelector.Items.Add("Sandstone Stairs(Any Sandstone)");
            RecipeSelector.Items.Add("Stone Stairs");
            RecipeSelector.Items.Add("Quartz Stairs(Any Quartz Block)");
            RecipeSelector.Items.Add("Red Sandstone Stairs(Any Red Sandstone)");

            RecipeSelector.Items.Add("Bread");
            RecipeSelector.Items.Add("Cake");
            RecipeSelector.Items.Add("Cookie");
            RecipeSelector.Items.Add("Wheat");
            RecipeSelector.Items.Add("Golden Apple");
            RecipeSelector.Items.Add("Enchanted Golden Apple");
            RecipeSelector.Items.Add("Golden Carrot");
            RecipeSelector.Items.Add("Mushroom Stew");
            RecipeSelector.Items.Add("Pumpkin Pie");
            RecipeSelector.Items.Add("Rabbit Stew");
            RecipeSelector.Items.Add("Book and Quill");

            RecipeSelector.Items.Add("Bucket");
            RecipeSelector.Items.Add("Eye of Ender");
            RecipeSelector.Items.Add("Fire Charge");
            RecipeSelector.Items.Add("Firework Rocket");
            RecipeSelector.Items.Add("Empty Map");
            RecipeSelector.Items.Add("Map(zoomed out)");
            RecipeSelector.Items.Add("Compass");
            RecipeSelector.Items.Add("Paper");
            RecipeSelector.Items.Add("Slime Ball (1.8+)");

            RecipeSelector.Items.Add("Bone Meal");
            RecipeSelector.Items.Add("Bowl");
            RecipeSelector.Items.Add("Cocoa Beans");
            RecipeSelector.Items.Add("Cyan Dye");
            RecipeSelector.Items.Add("Dandelion Yellow");
            RecipeSelector.Items.Add("Gray Dye");
            RecipeSelector.Items.Add("Leather");
            RecipeSelector.Items.Add("Sugar");

            RecipeSelector.Items.Add("Enderchest");
            RecipeSelector.Items.Add("Anvil");
            RecipeSelector.Items.Add("Book");
            RecipeSelector.Items.Add("Boat");
            RecipeSelector.Items.Add("Blaze Powder");

            RecipeSelector.Items.Add("Minecart");
            RecipeSelector.Items.Add("Minecart with Chest");
            RecipeSelector.Items.Add("Minecart with Furnace");
            RecipeSelector.Items.Add("Minecart with Hopper");
            RecipeSelector.Items.Add("Minecart with TNT");

            RecipeSelector.Items.Add("Magma Cream");
            RecipeSelector.Items.Add("Fermented Spider Eye");
            RecipeSelector.Items.Add("Glistering Melon");
            RecipeSelector.Items.Add("Glowstone");
            RecipeSelector.Items.Add("Jack o Lantern");
            RecipeSelector.Items.Add("Pumpkin Seeds");
            RecipeSelector.Items.Add("Melon Seeds");
            RecipeSelector.Items.Add("Melon(Block)");

            RecipeSelector.Items.Add("Detector Rail");
            RecipeSelector.Items.Add("Activator Rail");

            RecipeSelector.Items.Add("Daylight Sensor");
            RecipeSelector.Items.Add("Tripwire Hook");
            RecipeSelector.Items.Add("Trapped Chest");
            RecipeSelector.Items.Add("Weighted Pressure Plate (Heavy)");
            RecipeSelector.Items.Add("Weighted Pressure Plate (Light)");

            RecipeSelector.Items.Add("Iron Trap Door");
            RecipeSelector.Items.Add("Wooden Trap Door");

            RecipeSelector.Items.Add("Granite (1.8+)");
            RecipeSelector.Items.Add("Andesite (1.8+)");
            RecipeSelector.Items.Add("Diorite (1.8+)");
            RecipeSelector.Items.Add("Polished Granite (1.8+)");
            RecipeSelector.Items.Add("Polished Andesite (1.8+)");
            RecipeSelector.Items.Add("Polished Diorite (1.8+)");
            RecipeSelector.Items.Add("Prismarine (1.8+)");
            RecipeSelector.Items.Add("Prismarine Bricks (1.8+)");
            RecipeSelector.Items.Add("Dark Prismarine (1.8+)");
            RecipeSelector.Items.Add("Sea Lantern (1.8+)");
            RecipeSelector.Items.Add("Coarse Dirt (1.8+)");
            RecipeSelector.Items.Add("Slime Block (1.8+)");
            RecipeSelector.Items.Add("Rabbit Stew (1.8+)");
            RecipeSelector.Items.Add("Moss Stone (1.8+)");
            RecipeSelector.Items.Add("Mossy Stone Brick (1.8+)");
            RecipeSelector.Items.Add("Chiseled Stone Brick (1.8+)");
            RecipeSelector.Items.Add("Leather (1.8+)");

            //Potions
            potionSelector.Items.Add("Potion of Swiftness(3 Minutes)");
            potionSelector.Items.Add("Potion of Swiftness(8 Minutes)");
            potionSelector.Items.Add("Potion of Swiftness II");

            potionSelector.Items.Add("Potion of Fire Resistance(3 Minutes)");
            potionSelector.Items.Add("Potion of Fire Resistance(8 Minutes)");

            potionSelector.Items.Add("Potion of Slowness(1.30 Minutes)");
            potionSelector.Items.Add("Potion of Slowness(4 Minutes)");

            potionSelector.Items.Add("Potion of Water Breathing(3 Minutes)");
            potionSelector.Items.Add("Potion of Water Breathing(8 Minutes)");

            potionSelector.Items.Add("Potion of Healing");
            potionSelector.Items.Add("Potion of Healing II");

            potionSelector.Items.Add("Potion of Harming");
            potionSelector.Items.Add("Potion of Harming II");

            potionSelector.Items.Add("Potion of Poison(45 seconds)");
            potionSelector.Items.Add("Potion of Poison(2 Minutes)");
            potionSelector.Items.Add("Potion of Poison II");

            potionSelector.Items.Add("Potion of Night Vision(3 Minutes)");
            potionSelector.Items.Add("Potion of Night Vision(8 Minutes)");

            potionSelector.Items.Add("Potion of Invisibility(3 Minutes)");
            potionSelector.Items.Add("Potion of Invisibility(8 Minutes)");

            potionSelector.Items.Add("Potion of Regeneration(45 seconds)");
            potionSelector.Items.Add("Potion of Regeneration(2 Minutes)");
            potionSelector.Items.Add("Potion of Regeneration II");

            potionSelector.Items.Add("Potion of Strength(3 Minutes)");
            potionSelector.Items.Add("Potion of Strength(8 Minutes)");
            potionSelector.Items.Add("Potion of Strength II");

            potionSelector.Items.Add("Potion of Weakness(1.30 Minutes)");
            potionSelector.Items.Add("Potion of Weakness(4 Minutes)");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grid1.Image != null)
            {
                grid1.Image.Dispose();
                grid1.Image = null;
            }
            if (grid2.Image != null)
            {
                grid2.Image.Dispose();
                grid2.Image = null;
            }
            if (grid3.Image != null)
            {
                grid3.Image.Dispose();
                grid3.Image = null;
            }
            if (grid4.Image != null)
            {
                grid4.Image.Dispose();
                grid4.Image = null;
            }
            if (grid5.Image != null)
            {
                grid5.Image.Dispose();
                grid5.Image = null;
            }
            if (grid6.Image != null)
            {
                grid6.Image.Dispose();
                grid6.Image = null;
            }
            if (grid7.Image != null)
            {
                grid7.Image.Dispose();
                grid7.Image = null;
            }
            if (grid8.Image != null)
            {
                grid8.Image.Dispose();
                grid8.Image = null;
            }
            if (grid9.Image != null)
            {
                grid9.Image.Dispose();
                grid9.Image = null;
            }
            
            switch (RecipeSelector.Text)
            {
                case "Redstone Repeater":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/redstone_torch_on.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/redstone_torch_on.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    break;
                case "Redstone Lamp":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/glowstone.png");
                    break;
                case "Piston":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    break;
                case "Sticky Piston":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/piston_side.png");
                    break;
                case "Powered Rail":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Redstone Compartor":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/redstone_torch_on.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/redstone_torch_on.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/redstone_torch_on.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    break;
                case "Rail":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Dispenser":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/bow_standby.png");
                    break;
                case "Dropper":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    break;
                case "Hopper":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Chest.png");
                    break;
                case "Door (Any wood)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Iron Door":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    break;
                case "Fence Gate (Any wood)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Fence (Any wood)(1.7.0 and earlier)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Fence (Any wood)(1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Bow":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/string.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/string.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/string.png");
                    break;
                case "Fishing Rod":
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/string.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/string.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Lever":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    break;
                case "Tnt":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/gunpowder.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/gunpowder.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/gunpowder.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/gunpowder.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/gunpowder.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/sand.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/sand.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/sand.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/sand.png");
                    break;
                case "Bookshelf":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/book_normal.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/book_normal.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/book_normal.png");
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Beacon":
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/glass.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/glass.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/glass.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/glass.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/glass.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/nether_star.png");
                    break;
                case "Enchantment Table":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/book_normal.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                    break;
                case "Wood Pickaxe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Wood Axe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Wood Hoe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Wood Shovel":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Wood Sword":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Stone Pickaxe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Stone Axe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Stone Hoe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Stone Shovel":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Stone Sword":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Iron Pickaxe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Iron Axe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Iron Hoe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Iron Shovel":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Iron Sword":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Golden Pickaxe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Golden Axe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Golden Hoe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Golden Shovel":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Golden Sword":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Diamond Pickaxe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Diamond Axe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Diamond Hoe":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Diamond Shovel":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Diamond Sword":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                    break;
                case "Block of Gold":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                    break;
                case "Block of Coal":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                    break;
                case "Block of Iron":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                    break;
                case "Block of Diamond":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/diamond.png");
                    break;
                case "Block of Emerald":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/emerald.png");
                    break;
                case "Block of Quartz":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                    break;
                case "Block of Redstone":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    break;
                case "Block of Lapis":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                    break;
                case "Stone Button":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    break;
                case "Wooden Button":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Note Block":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Stone Pressure Plate":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    break;
                case "Wooden Pressure Plate":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Redstone":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/redstone_block.png");
                    break;
                case "Iron Ingot":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/iron_block.png");
                    break;
                case "Gold Ingot":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                    break;
                case "Coal":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/coal_block.png");
                    break;
                case "Diamond":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/diamond_block.png");
                    break;
                case "Emerald":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/emerald_block.png");
                    break;
                case "Lapis":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/lapis_block.png");
                    break;
                case "Wood Slab(Any wood)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Nether Brick Slab":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    break;
                case "Stone Bricks Slab(Any Stone Bricks)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    break;
                case "Bricks Slab":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    break;
                case "Cobblestone Slab":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    break;
                case "Sandstone Slab(Any Sandstone)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    break;
                case "Stone Slab":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    break;
                case "Quartz Slab(Any Quartz Block)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    break;
                case "Red Sandstone Slab(Any Red Sandstone)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    break;
                case "Wood Stairs(Any wood)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Nether Brick Stairs":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/nether_brick.png");
                    break;
                case "Stone Bricks Stairs(Any Stone Bricks)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    break;
                case "Bricks Stairs":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/brick.png");
                    break;
                case "Cobblestone Stairs":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    break;
                case "Sandstone Stairs(Any Sandstone)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/sandstone_normal.png");
                    break;
                case "Stone Stairs":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    break;
                case "Quartz Stairs(Any Quartz Block)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/quartz_block_side.png");
                    break;
                case "Red Sandstone Stairs(Any Red Sandstone)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/red_sandstone_normal.png");
                    break;
                case "Brewing Stand":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/blaze_rod.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    break;
                case "Bed":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/wool_colored_white.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/wool_colored_white.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/wool_colored_white.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                    break;
                case "Stone Bricks":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stone.png");
                    break;
                case "Bread":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/wheat.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/wheat.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/wheat.png");
                    break;
                case "Cake":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/bucket_milk.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/bucket_milk.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/bucket_milk.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/Sugar.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/egg.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/sugar.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/wheat.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/wheat.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/wheat.png");
                    break;
                case "Cookie":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/wheat.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_brown.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/wheat.png");
                    break;
                case "Golden Apple":
                   grid1.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                   grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                   grid3.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/apple.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                   grid7.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                   grid9.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                   break;
                case "Enchanted Golden Apple":
                   grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                   grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                   grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                   grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/apple.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                   grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                   grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/gold_block.png");
                   break;
                case "Golden Carrot":
                   grid1.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                   grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                   grid3.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/carrot.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                   grid7.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                   grid9.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                   break;
                case "Mushroom Stew":
                   grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/mushroom_red.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/mushroom_brown.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/bowl.png");
                   break;
                case "Pumpkin Pie":
                   grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/pumpkin_face_off.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/sugar.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/egg.png");
                   break;
                case "Rabbit Stew":
                   grid2.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_cooked.png");
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/carrot.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/potato_baked.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/mushroom_brown.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/bowl.png");
                   break;
                case "Book and Quill":
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/book_normal.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_black.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/feather.png");
                   break;
                case "Bucket":
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                   break;
                case "Eye of Ender":
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/blaze_powder.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/ender_pearl.png");
                   break;
                case "Fire Charge":
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/blaze_powder.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/coal.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/gunpowder.png");
                   break;
                case "Firework Rocket":
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/gunpowder.png");
                   break;
                case "Empty Map":
                   grid1.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid2.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid3.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/Grid_Compass.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid7.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid9.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   break;
                case "Map(zoomed out)":
                   grid1.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid2.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid3.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/map_filled.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid7.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   grid9.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                   break;
                case "Paper":
                   grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/reeds.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/reeds.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/reeds.png");
                   break;
                case "Compass":
                   grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                   grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                   grid6.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                   grid8.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                   grid5.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                   break;
                case "Slime Ball (1.8+)":
                   grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/slime.png");
                   break;
                case "Bone Meal":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/bone.png");
                  break;
                case "Bowl":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  break;
                case "Cocoa Beans":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_orange.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_black.png");
                  break;
                case "Cyan Dye":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_blue.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_green.png");
                  break;
                case "Dandelion Yellow":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/flower_dandelion.png");
                  break;
                case "Gray Dye":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_black.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_white.png");
                  break;
                case "Leather":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_hide.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_hide.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_hide.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_hide.png");
                  break;
                case "Sugar":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/reeds.png");
                  break;
                case "Wheat":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/hay_block_side.png");
                  break;
                case "Enderchest":
                  grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                  grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                  grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                  grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/ender_eye.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/obsidian.png");
                  break;
                case "Anvil":
                  grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/iron_block.png");
                  grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/iron_block.png");
                  grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/iron_block.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  break;
                case "Book":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/paper.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/leather.png");
                  break;
                case "Minecart":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  break;
                case "Minecart with Chest":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Chest.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/minecart_normal.png");
                  break;
                case "Minecart with Furnace":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/furnace_front_off.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/minecart_normal.png");
                  break;
                case "Minecart with Hopper":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/hopper.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/minecart_normal.png");
                  break;
                case "Minecart with TNT":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/tnt_side.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/minecart_normal.png");
                  break;
                case "Boat":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  break;
                case "Blaze Powder":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/blaze_rod.png");
                  break;
                case "Magma Cream":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/blaze_powder.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                  break;
                case "Fermented Spider Eye":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/mushroom_brown.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/sugar.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/spider_eye.png");
                  break;
                case "Glistering Melon":
                  grid1.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                  grid2.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                  grid3.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/items/gold_nugget.png");
                  break;
                case "Glowstone":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/glowstone_dust.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/glowstone_dust.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/glowstone_dust.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/glowstone_dust.png");
                  break;
                case "Jack o Lantern":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/pumpkin_face_off.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/torch_on.png");
                  break;
                case "Pumpkin Seeds":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/pumpkin_face_off.png");
                  break;
                case "Melon Seeds":
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  break;
                case "Melon(Block)":
                  grid1.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid2.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid3.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/items/melon.png");
                  break;
                case "Activator Rail":
                  grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid2.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                  grid3.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/redstone_torch_on.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  break;
                case "Detector Rail":
                  grid1.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid3.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Stone_Pressure_Plate.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/redstone_dust.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  break;
                case "Daylight Sensor":
                  grid1.ImageLocation = (Application.StartupPath + "/textures/blocks/glass.png");
                  grid2.ImageLocation = (Application.StartupPath + "/textures/blocks/glass.png");
                  grid3.ImageLocation = (Application.StartupPath + "/textures/blocks/glass.png");
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Oak_Wood_Slab.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Oak_Wood_Slab.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Oak_Wood_Slab.png");
                  break;
                case "Tripwire Hook":
                  grid2.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/stick.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  break;
                case "Trapped Chest":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/trip_wire_source.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Chest.png");
                  break;
                case "Weighted Pressure Plate (Heavy)":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  break;
                case "Weighted Pressure Plate (Light)":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/gold_ingot.png");
                  break;
                case "Iron Trap Door":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/items/iron_ingot.png");
                  break;
                case "Wooden Trap Door":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  grid9.ImageLocation = (Application.StartupPath + "/textures/blocks/planks_oak.png");
                  break;
                case "Granite (1.8+)":
                  grid4.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                  grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_diorite.png");
                    break;
                case "Andesite (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_diorite.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    break;
                case "Diorite (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_diorite.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/quartz.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_diorite.png");
                    break;
                case "Polished Granite (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_granite.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_granite.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_granite.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_granite.png");
                    break;
                case "Polished Andesite (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_andesite.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_andesite.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_andesite.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_andesite.png");
                    break;
                case "Polished Diorite (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_diorite.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_diorite.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_diorite.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/stone_diorite.png");
                    break;
                case "Prismarine (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    break;
                case "Prismarine Bricks (1.8+)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    break;
                case "Dark Prismarine (1.8+)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/dye_powder_black.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    break;
                case "Sea Lantern (1.8+)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_crystals.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_crystals.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_crystals.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_crystals.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_crystals.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/prismarine_shard.png");
                    break;
                case "Coarse Dirt (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/dirt.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/gravel.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/blocks/gravel.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/dirt.png");
                    break;
                case "Slime Block (1.8+)":
                    grid1.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid3.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    grid9.ImageLocation = (Application.StartupPath + "/textures/items/slimeball.png");
                    break;
                case "Rabbit Stew (1.8+)":
                    grid2.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_cooked.png");
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/carrot.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/potato.png");
                    grid6.ImageLocation = (Application.StartupPath + "/textures/blocks/mushroom_red.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/bowl.png");
                    break;
                case "Moss Stone (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/cobblestone.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/vine.png");
                    break;
                case "Mossy Stone Brick (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/blocks/stonebrick.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/vine.png");
                    break;
                case "Chiseled Stone Brick (1.8+)":
                    grid5.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Stone_Bricks_Slab.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/blocks/Grid_Stone_Bricks_Slab.png");
                    break;
                case "Leather (1.8+)":
                    grid4.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_hide.png");
                    grid5.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_hide.png");
                    grid7.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_hide.png");
                    grid8.ImageLocation = (Application.StartupPath + "/textures/items/rabbit_hide.png");
                    break;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            switch (potionSelector.Text)
            {
                case "Potion of Leaping(3 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Rabbits Foot");
                    break;
                case "Potion of Leaping(8 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Rabbits Foot");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Leaping II":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Rabbits Foot");
                    listBox1.Items.Add("Glowstone");
                    break;
                case "Potion of Swiftness(3 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Sugar");
                    break;
                case "Potion of Swiftness(8 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Sugar");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Swiftness II":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Sugar");
                    listBox1.Items.Add("Glowstone");
                    break;
                case "Potion of Fire Resistance(3 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Magma Cream");
                    break;
                case "Potion of Fire Resistance(8 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Magma Cream");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Slowness(1.30 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Magma Cream");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Rabbits Foot");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Sugar");
                    listBox1.Items.Add("Fermented Spider Eye");
                    break;
                case "Potion of Slowness(4 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Magma Cream");
                    listBox1.Items.Add("Redstone Dust");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Rabbits Foot");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("Redstone Dust");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Sugar");
                    listBox1.Items.Add("Redstone Dust");
                    listBox1.Items.Add("Fermented Spider Eye");
                    break;
                case "Potion of Water Breathing(3 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Pufferfish");
                    break;
                case "Potion of Water Breathing(8 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Pufferfish");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Healing":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Glistering Melon");
                    break;
                case "Potion of Healing II":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Glistering Melon");
                    listBox1.Items.Add("Glowstone");
                    break;
                case "Potion of Harming":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Glistering Melon");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Pufferfish");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Glistering Melon");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Spider Eye");
                    listBox1.Items.Add("Fermented Spider Eye");
                    break;
                case "Potion of Harming II":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Glistering Melon");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("Glowstone");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Glistering Melon");
                    listBox1.Items.Add("Glowstone");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Spider Eye");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("Glowstone");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Spider Eye");
                    listBox1.Items.Add("Glowstone");
                    listBox1.Items.Add("Fermented Spider Eye");
                    break;
                case "Potion of Poison(45 seconds)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Spider Eye");
                    break;
                case "Potion of Poison(2 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Spider Eye");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Poison II":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Spider Eye");
                    listBox1.Items.Add("Glowstone");
                    break;
                case "Potion of Night Vision(3 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Golden Carrot");
                    break;
                case "Potion of Night Vision(8 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Golden Carrot");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Invisibility(3 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Golden Carrot");
                    listBox1.Items.Add("Fermented Spider Eye");
                    break;
                case "Potion of Invisibility(8 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Golden Carrot");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Regeneration(45 seconds)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Ghast Tear");
                    break;
                case "Potion of Regeneration(2 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Ghast Tear");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Regeneration II":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Ghast Tear");
                    listBox1.Items.Add("Glowstone");
                    break;
                case "Potion of Strength(3 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Blaze Powder");
                    break;
                case "Potion of Strength(8 Minutes)":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Blaze Powder");
                    listBox1.Items.Add("Redstone Dust");
                    break;
                case "Potion of Strength II":
                    listBox1.Items.Add("Nether Wart");
                    listBox1.Items.Add("Blaze Powder");
                    listBox1.Items.Add("Glowstone");
                    break;
                case "Potion of Weakness(1.30 Minutes)":
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("--Any of the below--");
                    listBox1.Items.Add("Magma Cream");
                    listBox1.Items.Add("Sugar");
                    listBox1.Items.Add("Pufferfish");
                    listBox1.Items.Add("Glistering Melon");
                    listBox1.Items.Add("Spider Eye");
                    listBox1.Items.Add("Golden Carrot");
                    listBox1.Items.Add("Ghast Tear");
                    listBox1.Items.Add("Blaze Powder");
                    listBox1.Items.Add("-----------------");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Glowstone");
                    listBox1.Items.Add("Fermented Spider Eye");
                    break;
                case "Potion of Weakness(4 Minutes)":
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("Redstone Dust");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("--Any of the below--");
                    listBox1.Items.Add("Magma Cream");
                    listBox1.Items.Add("Sugar");
                    listBox1.Items.Add("Pufferfish");
                    listBox1.Items.Add("Glistering Melon");
                    listBox1.Items.Add("Spider Eye");
                    listBox1.Items.Add("Golden Carrot");
                    listBox1.Items.Add("Ghast Tear");
                    listBox1.Items.Add("Blaze Powder");
                    listBox1.Items.Add("-----------------");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Glowstone");
                    listBox1.Items.Add("Fermented Spider Eye");
                    listBox1.Items.Add("-----OR-----");
                    listBox1.Items.Add("Redstone Dust");
                    listBox1.Items.Add("Fermented Spider Eye");
                    break;
            }
        }

        private void btnSlimeChunk_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/slime-finder");       
        }

        private void btnBiome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/biome-finder");
        }

        private void btnVillage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/village-finder");
        }

        private void btnNetherFortness_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/nether-fortress-finder");
        }

        private void btnStrongHold_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/stronghold-finder");
        }

        private void btnMineshaft_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/mineshaft-finder");
        }

        private void btnDesertTemple_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/desert-temple-finder");
        }

        private void btnJungleTemple_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/jungle-temple-finder");
        }

        private void btnWitchHut_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/witch-hut-finder");
        }

        private void btnMoument_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://chunkbase.com/apps/ocean-monument-finder");
        }

        string latestversion = "1.0.0.0";
        string downlink = null;

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Process.Start(downlink);
        }

        private void Checkforupdate()
        {
            System.IO.Stream Str = null;
            System.IO.StreamReader srRead = null;
            System.IO.Stream Str2 = null;
            System.IO.StreamReader srRead2 = null;
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create("http://pastebin.com/raw.php?i=S4PdHVKd");
                System.Net.WebResponse resp = req.GetResponse();
                Str = resp.GetResponseStream();
                srRead = new System.IO.StreamReader(Str);

                latestversion = srRead.ReadToEnd();
                Properties.Settings.Default.LatestVersion = latestversion;
            }

            catch (Exception)
            {
                MessageBox.Show("Could recieve latest version! Please check your internet connection!");
            }

            try
            {
                System.Net.WebRequest req2 = System.Net.WebRequest.Create("http://pastebin.com/raw.php?i=99LNUJ5h");

                //i=zQS5MWLM
                System.Net.WebResponse resp2 = req2.GetResponse();
                Str2 = resp2.GetResponseStream();
                srRead2 = new System.IO.StreamReader(Str2);

                downlink = srRead2.ReadToEnd();
            }
            catch (Exception)
            {
                MessageBox.Show("Could recieve latest version! Please check your internet connection!");
            }

            LatestVersionL.Text = latestversion;
            MyVersionL.Text = "1.0.0.9";
            lblVersion.Text = MyVersionL.Text;

            if (LatestVersionL.Text != MyVersionL.Text)
            {
                MessageBox.Show("Update available! Please go to the Update Tab to update!");
                MyVersionL.ForeColor = Color.Red;
                button8.Visible = true;
                tabControl1.TabPages.Add(updatestab);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (txtX.Text == "" || txtZ.Text == "")
            {
                MessageBox.Show("Fill out all the boxs!", "Error!");
            }
            else
            {
                double numberx = 0;
                double numberz = 0;

                numberx = Convert.ToDouble(txtX.Text);
                numberz = Convert.ToDouble(txtZ.Text);

                if ((numberx / 16) % 2 == 0 || (numberx / 16) == 1 || (numberx / 16) == -1)
                {
                    txtXOutput.Text = "This is a chunk border";
                }
                else
                {
                    txtXOutput.Text = "This is not a chunk border";
                }
                if ((numberz / 16) % 2 == 0 || (numberz / 16) == 1 || (numberz / 16) == -1)
                {
                    txtZOutput.Text = "This is a chunk border";
                }
                else
                {
                    txtZOutput.Text = "This is not a chunk border";
                }
            }
        }

        private void btnReportBug_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.surveymonkey.com/s/9H8P3K9");
        }

        private void txtRegionX_TextChanged(object sender, EventArgs e)
        {
            if(txtRegionX.Text != "" && txtRegionZ.Text != "")
            {
                int regionX = (int)Math.Floor(Math.Floor((Convert.ToInt32(txtRegionX.Text) / 16) / 32.0));
                int regionZ = (int)Math.Floor(Math.Floor((Convert.ToInt32(txtRegionZ.Text) / 16) / 32.0));

                txtRegionOutput.Text = "r." + regionX + "." + regionZ + "mcr";
            }
        }

        private void txtRegionZ_TextChanged(object sender, EventArgs e)
        {
            if (txtRegionX.Text != "" && txtRegionZ.Text != "")
            {
                int regionX = (int)Math.Floor(Math.Floor((Convert.ToInt32(txtRegionX.Text) / 16) / 32.0));
                int regionZ = (int)Math.Floor(Math.Floor((Convert.ToInt32(txtRegionZ.Text) / 16) / 32.0));

                txtRegionOutput.Text = "r." + regionX + "." + regionZ + "mcr";
            }
        }
    }
}
