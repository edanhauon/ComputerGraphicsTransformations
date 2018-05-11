using System.ComponentModel;
using System.Windows;
using Size = System.Drawing.Size;

namespace CGTransformer
{
	partial class WindowForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MenuPanel = new System.Windows.Forms.Panel();
			this.Mirror = new System.Windows.Forms.CheckBox();
			this.Rotate = new System.Windows.Forms.CheckBox();
			this.Scale = new System.Windows.Forms.CheckBox();
			this.DrawButton = new System.Windows.Forms.Button();
			this.Tranfer = new System.Windows.Forms.CheckBox();
			this.Canvas = new System.Windows.Forms.PictureBox();
			this.xAxis = new System.Windows.Forms.CheckBox();
			this.yAxis = new System.Windows.Forms.CheckBox();
			this.MenuPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
			this.SuspendLayout();
			// 
			// MenuPanel
			// 
			this.MenuPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.MenuPanel.Controls.Add(this.yAxis);
			this.MenuPanel.Controls.Add(this.xAxis);
			this.MenuPanel.Controls.Add(this.Mirror);
			this.MenuPanel.Controls.Add(this.Rotate);
			this.MenuPanel.Controls.Add(this.Scale);
			this.MenuPanel.Controls.Add(this.DrawButton);
			this.MenuPanel.Controls.Add(this.Tranfer);
			this.MenuPanel.Location = new System.Drawing.Point(49, 41);
			this.MenuPanel.Name = "MenuPanel";
			this.MenuPanel.Size = new System.Drawing.Size(1775, 228);
			this.MenuPanel.TabIndex = 0;
			// 
			// Mirror
			// 
			this.Mirror.AutoSize = true;
			this.Mirror.Location = new System.Drawing.Point(520, 117);
			this.Mirror.Name = "Mirror";
			this.Mirror.Size = new System.Drawing.Size(100, 29);
			this.Mirror.TabIndex = 4;
			this.Mirror.Text = "Mirror";
			this.Mirror.UseVisualStyleBackColor = true;
			this.Mirror.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Rotate
			// 
			this.Rotate.AutoSize = true;
			this.Rotate.Location = new System.Drawing.Point(390, 117);
			this.Rotate.Name = "Rotate";
			this.Rotate.Size = new System.Drawing.Size(107, 29);
			this.Rotate.TabIndex = 3;
			this.Rotate.Text = "Rotate";
			this.Rotate.UseVisualStyleBackColor = true;
			this.Rotate.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Scale
			// 
			this.Scale.AutoSize = true;
			this.Scale.Location = new System.Drawing.Point(256, 117);
			this.Scale.Name = "Scale";
			this.Scale.Size = new System.Drawing.Size(98, 29);
			this.Scale.TabIndex = 2;
			this.Scale.Text = "Scale";
			this.Scale.UseVisualStyleBackColor = true;
			this.Scale.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// DrawButton
			// 
			this.DrawButton.Location = new System.Drawing.Point(84, 26);
			this.DrawButton.Name = "DrawButton";
			this.DrawButton.Size = new System.Drawing.Size(179, 48);
			this.DrawButton.TabIndex = 1;
			this.DrawButton.Text = "Draw";
			this.DrawButton.UseVisualStyleBackColor = true;
			this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
			// 
			// Tranfer
			// 
			this.Tranfer.AutoSize = true;
			this.Tranfer.Location = new System.Drawing.Point(84, 117);
			this.Tranfer.Name = "Tranfer";
			this.Tranfer.Size = new System.Drawing.Size(113, 29);
			this.Tranfer.TabIndex = 0;
			this.Tranfer.Text = "Tranfer";
			this.Tranfer.UseVisualStyleBackColor = true;
			this.Tranfer.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// Canvas
			// 
			this.Canvas.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.Canvas.Location = new System.Drawing.Point(49, 309);
			this.Canvas.Name = "Canvas";
			this.Canvas.Size = new System.Drawing.Size(1775, 1154);
			this.Canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.Canvas.TabIndex = 1;
			this.Canvas.TabStop = false;
			this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
			this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
			this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
			// 
			// xAxis
			// 
			this.xAxis.AutoSize = true;
			this.xAxis.Location = new System.Drawing.Point(363, 44);
			this.xAxis.Name = "xAxis";
			this.xAxis.Size = new System.Drawing.Size(55, 29);
			this.xAxis.TabIndex = 5;
			this.xAxis.Text = "x";
			this.xAxis.UseVisualStyleBackColor = true;
			// 
			// yAxis
			// 
			this.yAxis.AutoSize = true;
			this.yAxis.Location = new System.Drawing.Point(442, 45);
			this.yAxis.Name = "yAxis";
			this.yAxis.Size = new System.Drawing.Size(55, 29);
			this.yAxis.TabIndex = 6;
			this.yAxis.Text = "y";
			this.yAxis.UseVisualStyleBackColor = true;
			// 
			// WindowForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1964, 1518);
			this.Controls.Add(this.Canvas);
			this.Controls.Add(this.MenuPanel);
			this.Name = "WindowForm";
			this.Text = "Transformer";
			this.MenuPanel.ResumeLayout(false);
			this.MenuPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MenuPanel;
		private System.Windows.Forms.PictureBox Canvas;
		private System.Windows.Forms.CheckBox Tranfer;
		private System.Windows.Forms.Button DrawButton;
		private new System.Windows.Forms.CheckBox Scale;
		private System.Windows.Forms.CheckBox Rotate;
		private System.Windows.Forms.CheckBox Mirror;
		private System.Windows.Forms.CheckBox xAxis;
		private System.Windows.Forms.CheckBox yAxis;
	}
}

