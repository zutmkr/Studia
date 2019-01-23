namespace lab2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtQuotesInput = new System.Windows.Forms.TextBox();
            this.txtQuotesOutput = new System.Windows.Forms.TextBox();
            this.btnQuotes = new System.Windows.Forms.Button();
            this.txtResolveInput = new System.Windows.Forms.TextBox();
            this.txtResolveOutput = new System.Windows.Forms.TextBox();
            this.resolve = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Button();
            this.txtTimeOutput = new System.Windows.Forms.TextBox();
            this.echo = new System.Windows.Forms.Button();
            this.txtEchoOutput = new System.Windows.Forms.TextBox();
            this.txtEchoInput = new System.Windows.Forms.TextBox();
            this.weather = new System.Windows.Forms.Button();
            this.txtWeatherOutputTemperature = new System.Windows.Forms.TextBox();
            this.weatherTime = new System.Windows.Forms.TextBox();
            this.echoTime = new System.Windows.Forms.TextBox();
            this.timeTime = new System.Windows.Forms.TextBox();
            this.resolveTime = new System.Windows.Forms.TextBox();
            this.btnQuotesTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWeatherInput = new System.Windows.Forms.TextBox();
            this.btnAllFunctions = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWaetherOutputLocation = new System.Windows.Forms.TextBox();
            this.txtWaetherOutputTime = new System.Windows.Forms.TextBox();
            this.txtWaetherOutputWind = new System.Windows.Forms.TextBox();
            this.txtWaetherOutputSkyConditions = new System.Windows.Forms.TextBox();
            this.txtWaetherOutputDewPoint = new System.Windows.Forms.TextBox();
            this.txtWaetherOutputPressure = new System.Windows.Forms.TextBox();
            this.txtWaetherOutputVisibility = new System.Windows.Forms.TextBox();
            this.async = new System.Windows.Forms.Button();
            this.txtElapsedAllWatch = new System.Windows.Forms.TextBox();
            this.txtAsyncWatch = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtQuotesInput
            // 
            this.txtQuotesInput.Location = new System.Drawing.Point(9, 21);
            this.txtQuotesInput.Name = "txtQuotesInput";
            this.txtQuotesInput.Size = new System.Drawing.Size(100, 20);
            this.txtQuotesInput.TabIndex = 0;
            this.txtQuotesInput.Text = "GOOG";
            // 
            // txtQuotesOutput
            // 
            this.txtQuotesOutput.Location = new System.Drawing.Point(296, 21);
            this.txtQuotesOutput.Name = "txtQuotesOutput";
            this.txtQuotesOutput.Size = new System.Drawing.Size(100, 20);
            this.txtQuotesOutput.TabIndex = 1;
            // 
            // btnQuotes
            // 
            this.btnQuotes.Location = new System.Drawing.Point(171, 19);
            this.btnQuotes.Name = "btnQuotes";
            this.btnQuotes.Size = new System.Drawing.Size(75, 23);
            this.btnQuotes.TabIndex = 2;
            this.btnQuotes.Text = "btnQuotes";
            this.btnQuotes.UseVisualStyleBackColor = true;
            this.btnQuotes.Click += new System.EventHandler(this.btnQuotes_Click);
            // 
            // txtResolveInput
            // 
            this.txtResolveInput.Location = new System.Drawing.Point(9, 19);
            this.txtResolveInput.Name = "txtResolveInput";
            this.txtResolveInput.Size = new System.Drawing.Size(100, 20);
            this.txtResolveInput.TabIndex = 3;
            this.txtResolveInput.Text = "151.101.0.81";
            // 
            // txtResolveOutput
            // 
            this.txtResolveOutput.Location = new System.Drawing.Point(296, 19);
            this.txtResolveOutput.Name = "txtResolveOutput";
            this.txtResolveOutput.Size = new System.Drawing.Size(100, 20);
            this.txtResolveOutput.TabIndex = 4;
            // 
            // resolve
            // 
            this.resolve.Location = new System.Drawing.Point(171, 19);
            this.resolve.Name = "resolve";
            this.resolve.Size = new System.Drawing.Size(75, 23);
            this.resolve.TabIndex = 5;
            this.resolve.Text = "resolve";
            this.resolve.UseVisualStyleBackColor = true;
            this.resolve.Click += new System.EventHandler(this.resolve_Click);
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(171, 19);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(75, 23);
            this.time.TabIndex = 8;
            this.time.Text = "time";
            this.time.UseVisualStyleBackColor = true;
            this.time.Click += new System.EventHandler(this.time_Click);
            // 
            // txtTimeOutput
            // 
            this.txtTimeOutput.Location = new System.Drawing.Point(296, 19);
            this.txtTimeOutput.Name = "txtTimeOutput";
            this.txtTimeOutput.Size = new System.Drawing.Size(100, 20);
            this.txtTimeOutput.TabIndex = 7;
            // 
            // echo
            // 
            this.echo.Location = new System.Drawing.Point(171, 19);
            this.echo.Name = "echo";
            this.echo.Size = new System.Drawing.Size(75, 23);
            this.echo.TabIndex = 11;
            this.echo.Text = "echo";
            this.echo.UseVisualStyleBackColor = true;
            this.echo.Click += new System.EventHandler(this.echo_Click);
            // 
            // txtEchoOutput
            // 
            this.txtEchoOutput.Location = new System.Drawing.Point(296, 19);
            this.txtEchoOutput.Name = "txtEchoOutput";
            this.txtEchoOutput.Size = new System.Drawing.Size(222, 20);
            this.txtEchoOutput.TabIndex = 10;
            // 
            // txtEchoInput
            // 
            this.txtEchoInput.Location = new System.Drawing.Point(9, 19);
            this.txtEchoInput.Name = "txtEchoInput";
            this.txtEchoInput.Size = new System.Drawing.Size(100, 20);
            this.txtEchoInput.TabIndex = 9;
            this.txtEchoInput.Text = "test";
            // 
            // weather
            // 
            this.weather.Location = new System.Drawing.Point(171, 19);
            this.weather.Name = "weather";
            this.weather.Size = new System.Drawing.Size(75, 23);
            this.weather.TabIndex = 14;
            this.weather.Text = "weather";
            this.weather.UseVisualStyleBackColor = true;
            this.weather.Click += new System.EventHandler(this.weather_Click);
            // 
            // txtWeatherOutputTemperature
            // 
            this.txtWeatherOutputTemperature.Location = new System.Drawing.Point(418, 149);
            this.txtWeatherOutputTemperature.Name = "txtWeatherOutputTemperature";
            this.txtWeatherOutputTemperature.Size = new System.Drawing.Size(100, 20);
            this.txtWeatherOutputTemperature.TabIndex = 13;
            // 
            // weatherTime
            // 
            this.weatherTime.Location = new System.Drawing.Point(622, 19);
            this.weatherTime.Name = "weatherTime";
            this.weatherTime.Size = new System.Drawing.Size(100, 20);
            this.weatherTime.TabIndex = 15;
            // 
            // echoTime
            // 
            this.echoTime.Location = new System.Drawing.Point(622, 19);
            this.echoTime.Name = "echoTime";
            this.echoTime.Size = new System.Drawing.Size(100, 20);
            this.echoTime.TabIndex = 16;
            // 
            // timeTime
            // 
            this.timeTime.Location = new System.Drawing.Point(622, 19);
            this.timeTime.Name = "timeTime";
            this.timeTime.Size = new System.Drawing.Size(100, 20);
            this.timeTime.TabIndex = 17;
            // 
            // resolveTime
            // 
            this.resolveTime.Location = new System.Drawing.Point(622, 19);
            this.resolveTime.Name = "resolveTime";
            this.resolveTime.Size = new System.Drawing.Size(100, 20);
            this.resolveTime.TabIndex = 18;
            // 
            // btnQuotesTime
            // 
            this.btnQuotesTime.Location = new System.Drawing.Point(622, 19);
            this.btnQuotesTime.Name = "btnQuotesTime";
            this.btnQuotesTime.Size = new System.Drawing.Size(100, 20);
            this.btnQuotesTime.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(642, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "TIME OF EXEC";
            // 
            // txtWeatherInput
            // 
            this.txtWeatherInput.Location = new System.Drawing.Point(9, 22);
            this.txtWeatherInput.Multiline = true;
            this.txtWeatherInput.Name = "txtWeatherInput";
            this.txtWeatherInput.Size = new System.Drawing.Size(100, 149);
            this.txtWeatherInput.TabIndex = 21;
            this.txtWeatherInput.Text = "Szczecin";
            // 
            // btnAllFunctions
            // 
            this.btnAllFunctions.Location = new System.Drawing.Point(40, 26);
            this.btnAllFunctions.Name = "btnAllFunctions";
            this.btnAllFunctions.Size = new System.Drawing.Size(75, 23);
            this.btnAllFunctions.TabIndex = 22;
            this.btnAllFunctions.Text = "ALL";
            this.btnAllFunctions.UseVisualStyleBackColor = true;
            this.btnAllFunctions.Click += new System.EventHandler(this.btnAllFunctions_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQuotes);
            this.groupBox1.Controls.Add(this.txtQuotesInput);
            this.groupBox1.Controls.Add(this.txtQuotesOutput);
            this.groupBox1.Controls.Add(this.btnQuotesTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 49);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quotes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "INPUT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "OUTPUT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.resolve);
            this.groupBox2.Controls.Add(this.txtResolveInput);
            this.groupBox2.Controls.Add(this.txtResolveOutput);
            this.groupBox2.Controls.Add(this.resolveTime);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 49);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resolve";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtTimeOutput);
            this.groupBox3.Controls.Add(this.time);
            this.groupBox3.Controls.Add(this.timeTime);
            this.groupBox3.Location = new System.Drawing.Point(12, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(738, 49);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "NO INPUT";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtEchoOutput);
            this.groupBox4.Controls.Add(this.txtEchoInput);
            this.groupBox4.Controls.Add(this.echo);
            this.groupBox4.Controls.Add(this.echoTime);
            this.groupBox4.Location = new System.Drawing.Point(12, 208);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(738, 49);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Echo";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtWaetherOutputLocation);
            this.groupBox5.Controls.Add(this.txtWaetherOutputTime);
            this.groupBox5.Controls.Add(this.txtWaetherOutputWind);
            this.groupBox5.Controls.Add(this.txtWaetherOutputSkyConditions);
            this.groupBox5.Controls.Add(this.txtWaetherOutputDewPoint);
            this.groupBox5.Controls.Add(this.txtWaetherOutputPressure);
            this.groupBox5.Controls.Add(this.txtWaetherOutputVisibility);
            this.groupBox5.Controls.Add(this.weather);
            this.groupBox5.Controls.Add(this.txtWeatherOutputTemperature);
            this.groupBox5.Controls.Add(this.weatherTime);
            this.groupBox5.Controls.Add(this.txtWeatherInput);
            this.groupBox5.Location = new System.Drawing.Point(12, 263);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(738, 239);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Weather";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(344, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Location";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(344, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Time";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(344, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Wind";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "SkyConditions";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(344, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Temperature";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(344, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Visibility";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Pressure";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "DewPoint";
            // 
            // txtWaetherOutputLocation
            // 
            this.txtWaetherOutputLocation.Location = new System.Drawing.Point(418, 19);
            this.txtWaetherOutputLocation.Name = "txtWaetherOutputLocation";
            this.txtWaetherOutputLocation.Size = new System.Drawing.Size(100, 20);
            this.txtWaetherOutputLocation.TabIndex = 28;
            // 
            // txtWaetherOutputTime
            // 
            this.txtWaetherOutputTime.Location = new System.Drawing.Point(418, 45);
            this.txtWaetherOutputTime.Name = "txtWaetherOutputTime";
            this.txtWaetherOutputTime.Size = new System.Drawing.Size(100, 20);
            this.txtWaetherOutputTime.TabIndex = 27;
            // 
            // txtWaetherOutputWind
            // 
            this.txtWaetherOutputWind.Location = new System.Drawing.Point(418, 71);
            this.txtWaetherOutputWind.Name = "txtWaetherOutputWind";
            this.txtWaetherOutputWind.Size = new System.Drawing.Size(100, 20);
            this.txtWaetherOutputWind.TabIndex = 26;
            // 
            // txtWaetherOutputSkyConditions
            // 
            this.txtWaetherOutputSkyConditions.Location = new System.Drawing.Point(418, 123);
            this.txtWaetherOutputSkyConditions.Name = "txtWaetherOutputSkyConditions";
            this.txtWaetherOutputSkyConditions.Size = new System.Drawing.Size(100, 20);
            this.txtWaetherOutputSkyConditions.TabIndex = 25;
            // 
            // txtWaetherOutputDewPoint
            // 
            this.txtWaetherOutputDewPoint.Location = new System.Drawing.Point(418, 175);
            this.txtWaetherOutputDewPoint.Name = "txtWaetherOutputDewPoint";
            this.txtWaetherOutputDewPoint.Size = new System.Drawing.Size(100, 20);
            this.txtWaetherOutputDewPoint.TabIndex = 24;
            // 
            // txtWaetherOutputPressure
            // 
            this.txtWaetherOutputPressure.Location = new System.Drawing.Point(418, 201);
            this.txtWaetherOutputPressure.Name = "txtWaetherOutputPressure";
            this.txtWaetherOutputPressure.Size = new System.Drawing.Size(100, 20);
            this.txtWaetherOutputPressure.TabIndex = 23;
            // 
            // txtWaetherOutputVisibility
            // 
            this.txtWaetherOutputVisibility.Location = new System.Drawing.Point(418, 97);
            this.txtWaetherOutputVisibility.Name = "txtWaetherOutputVisibility";
            this.txtWaetherOutputVisibility.Size = new System.Drawing.Size(100, 20);
            this.txtWaetherOutputVisibility.TabIndex = 22;
            // 
            // async
            // 
            this.async.Location = new System.Drawing.Point(40, 71);
            this.async.Name = "async";
            this.async.Size = new System.Drawing.Size(75, 23);
            this.async.TabIndex = 27;
            this.async.Text = "ASYNC";
            this.async.UseVisualStyleBackColor = true;
            this.async.Click += new System.EventHandler(this.async_Click);
            // 
            // txtElapsedAllWatch
            // 
            this.txtElapsedAllWatch.Location = new System.Drawing.Point(260, 26);
            this.txtElapsedAllWatch.Name = "txtElapsedAllWatch";
            this.txtElapsedAllWatch.Size = new System.Drawing.Size(100, 20);
            this.txtElapsedAllWatch.TabIndex = 20;
            // 
            // txtAsyncWatch
            // 
            this.txtAsyncWatch.Location = new System.Drawing.Point(260, 73);
            this.txtAsyncWatch.Name = "txtAsyncWatch";
            this.txtAsyncWatch.Size = new System.Drawing.Size(100, 20);
            this.txtAsyncWatch.TabIndex = 29;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAllFunctions);
            this.groupBox6.Controls.Add(this.txtAsyncWatch);
            this.groupBox6.Controls.Add(this.async);
            this.groupBox6.Controls.Add(this.txtElapsedAllWatch);
            this.groupBox6.Location = new System.Drawing.Point(374, 518);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(376, 106);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ALL vs ASYNC";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 636);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuotesInput;
        private System.Windows.Forms.TextBox txtQuotesOutput;
        private System.Windows.Forms.Button btnQuotes;
        private System.Windows.Forms.TextBox txtResolveInput;
        private System.Windows.Forms.TextBox txtResolveOutput;
        private System.Windows.Forms.Button resolve;
        private System.Windows.Forms.Button time;
        private System.Windows.Forms.TextBox txtTimeOutput;
        private System.Windows.Forms.Button echo;
        private System.Windows.Forms.TextBox txtEchoOutput;
        private System.Windows.Forms.TextBox txtEchoInput;
        private System.Windows.Forms.Button weather;
        private System.Windows.Forms.TextBox txtWeatherOutputTemperature;
        private System.Windows.Forms.TextBox weatherTime;
        private System.Windows.Forms.TextBox echoTime;
        private System.Windows.Forms.TextBox timeTime;
        private System.Windows.Forms.TextBox resolveTime;
        private System.Windows.Forms.TextBox btnQuotesTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWeatherInput;
        private System.Windows.Forms.Button btnAllFunctions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtWaetherOutputLocation;
        private System.Windows.Forms.TextBox txtWaetherOutputTime;
        private System.Windows.Forms.TextBox txtWaetherOutputWind;
        private System.Windows.Forms.TextBox txtWaetherOutputSkyConditions;
        private System.Windows.Forms.TextBox txtWaetherOutputDewPoint;
        private System.Windows.Forms.TextBox txtWaetherOutputPressure;
        private System.Windows.Forms.TextBox txtWaetherOutputVisibility;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button async;
        private System.Windows.Forms.TextBox txtElapsedAllWatch;
        private System.Windows.Forms.TextBox txtAsyncWatch;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}

