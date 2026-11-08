using System.ComponentModel;

namespace ED_Hud_Extension
{
    public partial class LabelButton : Label 
    {
        /* custom class designed to replace default window's ugly ass buttons
        *  its just a Label, but it handles being hovered over and clicked. woo.
        */ 
        private bool _isHovered = false;
        private bool _isPressed = false;

        private Color _defaultForeColor = ColorTranslator.FromHtml("#C04000");
        private Color _hoverForeColor = ColorTranslator.FromHtml("#FFCC99");
        private Color _pressedForeColor = Color.White;

        [Category("Appearance")]
        [Description("Button color when the mouse hovers over the control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color HoverForeColor
        {
            get => _hoverForeColor;
            set { _hoverForeColor = value; InvalidatedState(); }
        }

        [Category("Appearance")]
        [Description("Text color when the control is pressed down.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color PressedForeColor
        {
            get => _pressedForeColor;
            set { _pressedForeColor = value; InvalidatedState(); }
        }

        public LabelButton()
        {
            // Set up native interaction defaults
            this.Cursor = Cursors.Hand;
            this.Size = new Size(100, 30);
            this.TextAlign = ContentAlignment.MiddleCenter;

            // Cache the base colors initially
            _defaultForeColor = ForeColor;
        }

        // Capture base color changes if assigned via the designer

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (!_isHovered && !_isPressed) _defaultForeColor = ForeColor;
        }

        // --- Interaction Event Overrides ---

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            UpdateVisualState();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            _isPressed = false;
            UpdateVisualState();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isPressed = true;
                UpdateVisualState();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isPressed = false;
                UpdateVisualState();
            }
            base.OnMouseUp(e);
        }

        public void PerformClick()
        {
            if (CanSelect && Enabled)
            {
                MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                OnMouseClick(e);
            }
        }

        // --- Render State Engine ---

        private void UpdateVisualState()
        {
            if (_isPressed) { base.ForeColor = _pressedForeColor; }
            else if (_isHovered) { base.ForeColor = _hoverForeColor; }
            else { base.ForeColor = _defaultForeColor; }
        }


        private void InvalidatedState()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                Invalidate();
            }
        }
    }
}
