using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SK_03
{
    public class Item_Detail_UI
    {
        public Texture2D _detailTexture; // รูปภาพรายละเอียด
        private Vector2 _position;          // ตำแหน่งของ UI บนหน้าจอ
        private bool _isVisible;            // สถานะการแสดงผล UI
        private Rectangle DetailRec;

        public Item_Detail_UI()
        {
            _isVisible = false; // กำหนดให้เริ่มต้นไม่แสดงผล
        }

        // เมธอดสำหรับแสดงรายละเอียดของไอเทม
        public void Show(Texture2D detailTexture,Rectangle detailRec, Vector2 position)
        {
            _detailTexture = detailTexture;
            _position = position;
            _isVisible = true; // เปลี่ยนสถานะเป็นแสดงผล

            DetailRec = detailRec;
        }

        // เมธอดสำหรับซ่อนรายละเอียดของไอเทม
        public void Hide()
        {
            _isVisible = false; // เปลี่ยนสถานะเป็นไม่แสดงผล
        }

        // เมธอดสำหรับการตรวจสอบว่าตำแหน่งของเมาส์อยู่ในรายละเอียดหรือไม่
        public bool Contains(Vector2 position)
        {
            if (_detailTexture != null)
            {
                Rectangle rectangle = new Rectangle(_position.ToPoint(), new Point(_detailTexture.Width, _detailTexture.Height));
                return rectangle.Contains(position.ToPoint());
            }
            return false;
        }

        // เมธอดสำหรับการวาด UI ของรายละเอียดไอเทม
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_isVisible && _detailTexture != null)
            {
                spriteBatch.Draw(_detailTexture, _position, Color.White);
            }
        }
    }
}
