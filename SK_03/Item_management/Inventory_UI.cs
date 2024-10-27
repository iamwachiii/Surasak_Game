using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SK_03
{
    public class Inventory_UI : Sprite
    {
        private Inventory _inventory;           // เก็บข้อมูล Inventory
        private SpriteFont _font;               // ฟอนต์สำหรับการแสดงผลข้อความ
        private Texture2D _slotTexture;         // รูปภาพพื้นหลังของช่องเก็บของ
        private Rectangle _slotRec;
        public Texture2D _backgroundTexture;   // รูปภาพพื้นหลังของ Inventory UI
        public Vector2 _position;              // ตำแหน่งของ UI บนหน้าจอ

        private MouseState previousMouseState;  // เก็บสถานะของเมาส์ในเฟรมก่อนหน้า
        private Item_Detail_UI _itemDetailUI; // ตัวแปรสำหรับจัดการรายละเอียดไอเทม
        private Game1 game;

        public Inventory_UI(Inventory inventory, SpriteFont font, Texture2D slotTexture, Texture2D backgroundTexture, Vector2 position, Game1 game)
        {
            _inventory = inventory;
            _font = font;
            _slotTexture = slotTexture;
            _backgroundTexture = backgroundTexture; // เก็บรูปภาพพื้นหลัง
            _position = position; 
            this.game = game;

            
            // กำหนดค่าสถานะเมาส์ในเฟรมก่อนหน้า
            previousMouseState = Mouse.GetState();
        }
        // เมธอดสำหรับการวาด UI ของ Inventory
        public void Draw(SpriteBatch spriteBatch)
        {
            // วาดพื้นหลัง
            //if (game.isInventoryVisible == true)
                //spriteBatch.Draw(_backgroundTexture, _position, game.transparentColorUI);          

            Vector2 slotSize = new Vector2(80, 80);
            Vector2 spacing = new Vector2(16, 16);

            for (int i = 0; i < _inventory.Items.Count; i++)
            {
                Vector2 slotPosition = _position + new Vector2(65, 95) + new Vector2((slotSize.X + spacing.X) * (i % 4), (slotSize.Y + spacing.Y) * (i / 4));
                spriteBatch.Draw(_inventory.Items[i].Icon, slotPosition, _inventory.Items[i].IconRec, game.transparentColorUI);           
                // ตรวจสอบว่ารายละเอียดของไอเทมควรแสดงหรือไม่
                if (_inventory.Items[i].IsDetailVisible)
                {
                    // วาดรายละเอียดของไอเทมที่ตำแหน่งที่เหมาะสม// 1040 232
                    float Width, Height;
                    Width = _backgroundTexture.Width + _position.X - 400;
                    Height = _backgroundTexture.Height + _position.Y - 648;


                    spriteBatch.Draw(_inventory.Items[i].DetailTexture, new Vector2(Width, Height), _inventory.Items[i].DetailRec, game.transparentColorUI);
                }
            }

        }

        // เมธอดสำหรับการตรวจสอบการคลิกของเมาส์ใน Inventory UI
        public void HandleInput(MouseState mouseState)
        {
            Vector2 slotSize = new Vector2(80, 80);
            Vector2 spacing = new Vector2(16, 16);

            for (int i = 0; i < _inventory.Items.Count; i++)
            {
                Vector2 slotPosition = _position + new Vector2(65, 95) + new Vector2((slotSize.X + spacing.X) * (i % 4), (slotSize.Y + spacing.Y) * (i / 4));
                Rectangle slotRectangle = new Rectangle(slotPosition.ToPoint(), slotSize.ToPoint());

                if (slotRectangle.Contains(mouseState.Position) &&
                    mouseState.LeftButton == ButtonState.Pressed &&
                    previousMouseState.LeftButton == ButtonState.Released)
                {
                    // ถ้าหากมีการเปิดรายละเอียดของไอเทมอื่นอยู่ ปิดการแสดงผล
                    foreach (var item in _inventory.Items)
                    {
                        if (item != _inventory.Items[i])
                        {
                            item.IsDetailVisible = false;
                        }
                    }

                    // สลับการแสดงรายละเอียดของไอเทมที่ถูกคลิก
                    _inventory.Items[i].IsDetailVisible = !_inventory.Items[i].IsDetailVisible;

                    // แสดงชื่อไอเทมใน Console
                    Console.WriteLine($"Clicked on item {_inventory.Items[i].Name}");
                }
            }

            previousMouseState = mouseState;
        }
    }
}
