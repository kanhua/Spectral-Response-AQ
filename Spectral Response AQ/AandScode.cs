//Defining the libraries that are being used:
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using VirtualGPIB;
using System.Diagnostics;
using NationalInstruments.NI4882;
using System.Threading;
using System.IO;

//Program:
namespace IR_QE
{
    public partial class mainform : Form
    {
        //Stop button = 0 unless pressed.
        int stopbuttonchar = 0;

        //Initialising monochromator and lock-in amplifier with GPIB settings.
        Device monochromator;
        Device LIA;

        //Defining filters:
        //NOTE - If you are changing the filters make sure you also change the boundaries under checkfilter()
        string Filter1 = "Filter 1: Open";
        string Filter2 = "Filter 2: 2000-3000nm";
        string Filter3 = "Filter 3: 1200-2000nm";
        string Filter4 = "Filter 4: 700-1200nm";
        string Filter5 = "Filter 5: 400-700nm";
        string Filter6 = "Filter 6: Black";

        public mainform()
        {

            InitializeComponent();

            //Disposing of old GPIB settings for the LIA.
            Byte newliagpib = Convert.ToByte(LIA_GPIB.Text);
            LIA = new Device(0, newliagpib, 0);

            //Disposing of old GPIB settings for the monochromator.
            Byte newgpib = Convert.ToByte(MC_GPIB.Text);
            monochromator = new Device(0, newgpib, 0);

            //Filters:

            //Clears list from previous settings
            currentfilter.Items.Clear();
            newfilter.Items.Clear();

            //Builds new lists with previously defined filters
            this.currentfilter.Items.AddRange(new object[] {
                Filter1,
                Filter2,
                Filter3,
                Filter4,
                Filter5,
                Filter6});

            this.newfilter.Items.AddRange(new object[] {
                Filter1,
                Filter2,
                Filter3,
                Filter4,
                Filter5,
                Filter6});

            //Monochromator default selection:
            automotorspeed.SelectedItem = "400";
            motorspeed.SelectedItem = "100";
            currentfilter.SelectedItem = Filter1;
            newfilter.SelectedItem = Filter1;
            autounits.SelectedItem = "Dial";
            MCmanunit.SelectedItem = "Dial";
            //Remember that "D0200T\n" will rotate filter wheel 360 degrees.

            //Calibration - These are default values for the diffraction grating and offset.
            grating.Text = "598.96";
            offset.Text = "-21.57";

            //Lock-In Amplifier default selection:
            input.SelectedItem = "Voltage: A";
            linefilter.SelectedItem = "50 and 100Hz";

            //Operation tab default selection:
            sweepstart.Text = "500";
            sweepend.Text = "2500";
            sweepstartunit.SelectedItem = "Wavelength (nm)";
            sweependunit.SelectedItem = "Wavelength (nm)";

        }


        //Producing a command for the monochromator, including digit correction:
        private string GenMCCommand(char direction, int step, char speed)
        {

            string command;
            string stepcorrection;

            //The following statements produce a 4 digit step number.
            if (step < 10)
            {
                stepcorrection = "000" + Convert.ToString(step);
            }
            else if (step < 100)
            {
                stepcorrection = "00" + Convert.ToString(step);
            }
            else if (step < 1000)
            {
                stepcorrection = "0" + Convert.ToString(step);
            }
            else
            {
                stepcorrection = Convert.ToString(step);
            }

            command = Convert.ToString(direction) + stepcorrection +
                      Convert.ToString(speed) + "\n";
            Debug.WriteLine(command);
            return command;

        }

        //Producing a command for the lock-in amplifier:
        private string GenLIACommand(string function, int n1)
        {

            string command;
            command = function + Convert.ToString(n1) + "\n";
            Debug.WriteLine(command);
            return command;

        }

        // 'Wavelength UP' button, including changing currentdial setting.
        private void wavelength_up_Click(object sender, EventArgs e)
        {
            double step = Convert.ToDouble(chanAStep.Text);
            string unit = MCmanunit.SelectedItem.ToString();


            switch (unit)
            {

                case "Wavelength (nm)":
                    step = wtod(step);
                    break;
                case "Dial":
                    break;
                //To see if a conversion between dial and wavelength values is needed.
            }
            //Safety:
            //These statements prevent the monochromator from going to unsafe values.
            if (MCcurrentdial.Text == "Enter Value")
            {
                MessageBox.Show("Enter value for current monochromator dial reading");
                //Pop-up box prompting user to enter a dial reading.
                return;
            }

            if (safetycheck(Convert.ToDouble(MCcurrentdial.Text) + step) == 1)
            {
                return;
            }

            int commandStep = Convert.ToInt16(step * 20);
            //step*20 as monochromator does not account for decimal point.

            //Defining the speed of the monochromator as R or W:
            char direction = 'I';            //I is the command for up.
            char speed = 'Z';                //False Character!
            string curItem = motorspeed.SelectedItem.ToString();

            switch (curItem)
            {

                case "100":
                    speed = 'W';
                    break;
                case "400":
                    speed = 'R';
                    break;
                default:
                    return;

            }

            string command = GenMCCommand(direction, commandStep, speed);
            monochromator.Write(command);
            double newsetting = Convert.ToDouble(MCcurrentdial.Text) + step;
            //newsetting calculates new currentdial readout.
            MCcurrentdial.Text = Convert.ToString(newsetting);
            //Changing the current dial read out.

        }

        //'Wavelength DOWN' button, including changing currentdial setting.
        private void wavelength_down_click(object sender, EventArgs e)
        {

            double step = Convert.ToDouble(chanAStep.Text);
            string unit = MCmanunit.SelectedItem.ToString();

            switch (unit)
            {

                case "Wavelength (nm)":
                    step = wtod(step);
                    break;
                case "Dial":
                    break;
                //To see if a conversion between dial and wavelength values is needed.

            }

            //Safety:
            //These statements prevent the monochromator from going to unsafe values.
            if (MCcurrentdial.Text == "Enter Value")
            {
                MessageBox.Show("Enter value for current monochromator dial reading");
                //Pop-up box prompting user to enter a dial reading.
                return;
            }
            if (safetycheck(Convert.ToDouble(MCcurrentdial.Text) - step) == 1)
            {
                return;
            }

            int commandStep = Convert.ToInt16(step * 20);
            //step*20 as monochromator does not account for decimal point.

            char direction = 'D';   //D is the comand for down.
            char speed = 'Z';       //False Character!
            string curItem = motorspeed.SelectedItem.ToString();

            switch (curItem)
            {
                case "100":
                    speed = 'W';
                    break;
                case "400":
                    speed = 'R';
                    break;
                default:
                    return;
            }

            string command = GenMCCommand(direction, commandStep, speed);
            monochromator.Write(command);
            double newsetting = Convert.ToDouble(MCcurrentdial.Text) - step;
            //newsetting calculates new currentdial readout.
            MCcurrentdial.Text = Convert.ToString(newsetting);
            //Changing the current dial read out.

        }

        //MC Autoset feature
        private void MC_autoset_click(object sender, EventArgs e)
        {
            //Safety:
            if (MCcurrentdial.Text == "Enter Value")
            {
                MessageBox.Show("Enter value for current monochromator dial reading");
                //Pop-up box prompting user to enter a dial reading.
                return;
            }

            if (safetycheck(Convert.ToDouble(MCnewsetting.Text)) == 1)
            {
                return;
            }

            double newsetting = Convert.ToDouble(MCnewsetting.Text);
            double currentdial = Convert.ToDouble(MCcurrentdial.Text);
            string unit = autounits.SelectedItem.ToString();

            switch (unit)
            {

                case "Wavelength (nm)":
                    newsetting = wtod(newsetting);
                    break;
                case "Dial":
                    break;
                //To see if a conversion between dial and wavelength values is needed.

            }

            //Working out the change needed, and also the direction:
            double changeneeded = newsetting - currentdial;
            char direction = 'Z';

            if (changeneeded < 0)   //Does not know if dial or wavelength
            {
                direction = 'D';
                changeneeded = -changeneeded;
            }

            else if (changeneeded > 0)
            {
                direction = 'I';
            }

            else
            {
                return;
            }

            int commandStep = Convert.ToInt16(changeneeded * 20);
            //step*20 as monochromator does not account for decimal point.

            //Speed selection:
            char speed = 'Z'; //False Character!
            string curItem = automotorspeed.SelectedItem.ToString();

            switch (curItem)
            {

                case "100":
                    speed = 'W';
                    break;
                case "400":
                    speed = 'R';
                    break;
                default:
                    return;

            }

            //Finally, sending the command to the monochromator:
            string command = GenMCCommand(direction, commandStep, speed);
            monochromator.Write(command);
            MCcurrentdial.Text = Convert.ToString(newsetting);
            //Changing the currentdial readout.

        }

        //Filter index
        private int filterindex(string filter)
        {
            int index = 99;

            //These statements define the filter index:
            if (filter == Filter1)
            {
                index = 0;
            }

            else if (filter == Filter2)
            {
                index = 1;
            }

            else if (filter == Filter3)
            {
                index = 2;
            }

            else if (filter == Filter4)
            {
                index = 3;
            }

            else if (filter == Filter5)
            {
                index = 4;
            }

            else if (filter == Filter6)
            {
                index = 5;
            }

            return index;

        }

        //Auto filter
        private void set_filter(object sender, EventArgs e)
        {
            //Current filter reset:
            string MCcurrentfilter = currentfilter.SelectedItem.ToString();
            int MCCFnumber = filterindex(MCcurrentfilter);

            string MCnewfilter = newfilter.SelectedItem.ToString();
            int MCNFnumber = filterindex(MCnewfilter);

            //If there is no change needed:
            if (MCNFnumber == MCCFnumber)
            {
                return;
            }

            //Else... Reset filter to Filter 1: Open:
            int commandStep = MCCFnumber * (200 / 6);
            char direction = 'D';
            char speed = 'T';
            string command = GenMCCommand(direction, commandStep, speed);
            monochromator.Write(command);

            Thread.Sleep(1000);
            //Waits for filter to physically change.

            //Set filter to new position
            commandStep = MCNFnumber * (200 / 6);
            direction = 'I';
            speed = 'T';
            command = GenMCCommand(direction, commandStep, speed);
            monochromator.Write(command);
            currentfilter.SelectedItem = MCnewfilter;
            //Updates program to display the new filter.

            Thread.Sleep(1000);
            //Waits for filter to physically change.

        }

        //Updating monochromator GBIP address
        private void updateGPIB_Click(object sender, EventArgs e)
        {

            monochromator.Dispose();
            Byte newgpib = Convert.ToByte(MC_GPIB.Text);
            monochromator = new Device(0, newgpib, 0);

        }

        //Converting a dial reading to a wavelength
        private double dtow(double dial)
        {

            double wave;
            wave = (dial * 1800 / Convert.ToDouble(grating.Text)) + Convert.ToDouble(offset.Text);
            //This uses user defined values for the grating and offset.
            return wave;

        }

        //Converting a wavelength to a dial reading
        private double wtod(double wave)
        {

            double dial;
            dial = (wave - Convert.ToDouble(offset.Text)) * (Convert.ToDouble(grating.Text) / 1800);
            //This uses user defined values for the grating and offset.
            return dial;

        }

        //Updating lock-in amplifier GPIB address
        private void LIA_GPIB_update_Click(object sender, EventArgs e)
        {

            LIA.Dispose();
            Byte newliagpib = Convert.ToByte(LIA_GPIB.Text);
            LIA = new Device(0, newliagpib, 0);

        }

        //Applying new lock-in amplifier settings
        private void button3_Click(object sender, EventArgs e)
        {

            ////Ref in frequency:
            string command = "IE 2\n";
            lockinwrite(command);

            //Setting the time constant (lots of cases):
            string function;
            function = "TC";
            string FilterTC = Convert.ToString(filtertc.SelectedItem);
            int FilterTCarg;

            switch (FilterTC)
            {

                case "10μs":
                    FilterTCarg = 0;
                    break;

                case "20μs":
                    FilterTCarg = 1;
                    break;

                case "40μs":
                    FilterTCarg = 2;
                    break;

                case "80μs":
                    FilterTCarg = 3;
                    break;

                case "1600μs":
                    FilterTCarg = 4;
                    break;

                case "320μs":
                    FilterTCarg = 5;
                    break;

                case "640μs":
                    FilterTCarg = 6;
                    break;

                case "5ms":
                    FilterTCarg = 7;
                    break;

                case "10ms":
                    FilterTCarg = 8;
                    break;

                case "20ms":
                    FilterTCarg = 9;
                    break;

                case "50ms":
                    FilterTCarg = 10;
                    break;

                case "100ms":
                    FilterTCarg = 11;
                    break;
                case "200ms":
                    FilterTCarg = 12;
                    break;

                case "500ms":
                    FilterTCarg = 13;
                    break;

                case "1s":
                    FilterTCarg = 14;
                    break;

                case "2s":
                    FilterTCarg = 15;
                    break;

                case "5s":
                    FilterTCarg = 16;
                    break;

                case "10s":
                    FilterTCarg = 17;
                    break;

                case "20s":
                    FilterTCarg = 18;
                    break;

                case "50s":
                    FilterTCarg = 19;
                    break;

                case "100s":
                    FilterTCarg = 20;
                    break;

                case "200s":
                    FilterTCarg = 21;
                    break;

                case "500s":
                    FilterTCarg = 22;
                    break;

                case "1ks":
                    FilterTCarg = 23;
                    break;

                case "2ks":
                    FilterTCarg = 24;
                    break;

                case "5ks":
                    FilterTCarg = 25;
                    break;

                case "10ks":
                    FilterTCarg = 26;
                    break;

                case "20ks":
                    FilterTCarg = 27;
                    break;

                case "50ks":
                    FilterTCarg = 28;
                    break;

                case "100ks":
                    FilterTCarg = 29;
                    break;

                default:
                    return;

            }

            command = GenLIACommand(function, FilterTCarg);
            lockinwrite(command);
            //Sending the time constant command.

            //Setting the line filter:
            function = "LF";
            string LFarg;
            string LFstate = Convert.ToString(linefilter.SelectedItem);

            switch (LFstate)
            {

                case "Off":
                    LFarg = " 0 0";
                    break;

                case "50Hz":
                    LFarg = " 1 1";
                    break;

                case "60Hz":
                    LFarg = " 1 0";
                    break;

                case "100Hz":
                    LFarg = " 2 1";
                    break;

                case "120Hz":
                    LFarg = " 2 0";
                    break;

                case "50 and 100Hz":
                    LFarg = " 3 1";
                    break;

                case "60 and 120Hz":
                    LFarg = " 3 0";
                    break;

                default:
                    return;

            }

            command = function + LFarg + "\n";
            lockinwrite(command);
            //Sending the line filter command.

            //Setting the input:
            function = "VMODE";
            string Input = Convert.ToString(input.SelectedItem);
            int Iarg;

            switch (Input)
            {

                case "Voltage: A":
                    Iarg = 1;
                    function = "VMODE";
                    lockinwrite("IMODE0\n");
                    break;

                case "Voltage: - B":
                    Iarg = 2;
                    function = "VMODE";
                    lockinwrite("IMODE0\n");
                    break;

                case "Voltage: A - B":
                    Iarg = 3;
                    function = "VMODE";
                    lockinwrite("IMODE0\n");
                    break;

                case "Current (High Bandwidth): B":
                    Iarg = 2;
                    function = "IMODE";
                    break;

                case "Current (Low Noise): B":
                    Iarg = 1;
                    function = "IMODE";
                    break;

                default:
                    return;

            }

            command = function + Convert.ToString(Iarg) + "\n";
            lockinwrite(command);
            //Sending the input command.

            //Setting bias voltage:
            button1_Click(sender, e);

            //Setting a suitable display for the lock-in amplifier:
            lockinwrite("DISPMODE1\n");
            lockinwrite("DISP 1 2\n");
            lockinwrite("DISP 2 3\n");
            lockinwrite("DISP 3 10\n");
            lockinwrite("DISPOUT 0 11\n");
            lockinwrite("DISPOUT 1 5\n");
            lockinwrite("DISPOUT 2 7\n");
            lockinwrite("DISPOUT 3 12\n");
        }

        //Auto-default
        private void autodefault_Click(object sender, EventArgs e)
        {

            string command = "ADF1\n";
            lockinwrite(command);
            lockinwrite("IE 2\n");
            //Makes LIA apply default settings.

        }

        //Auto-offset
        private void autooffset_Click(object sender, EventArgs e)
        {

            string command = "AXO\n";
            lockinwrite(command);
            //Makes LIA apply auto offset.

        }

        //Reading back frequency
        private void getfrequency_Click(object sender, EventArgs e)
        {

            string command = "IE 2\n";
            lockinwrite(command);
            ////Ref in frequency.

            command = "FRQ.\n";
            lockinwrite(command);
            //Sending frequency command to LIA.

            //Reading reply from LIA:
            string reply = LIA.ReadString();
            double test = Convert.ToDouble(reply);

            if (test > 3.0)
            {
                referencefrequency.Text = reply;
                //Frequency must be greater than 3...
            }

            else
            {
                referencefrequency.Text = "No signal detected";
                //...otherwise this will display.
            }

        }

        //Auto-sensitivity
        private void autosensitivity_Click(object sender, EventArgs e)
        {

            string command = "AS\n";
            lockinwrite(command);
            //Makes LIA autosensitise

        }

        //Auto-measure
        private void automeasure_Click(object sender, EventArgs e)
        {

            string command = "ASM\n";
            lockinwrite(command);
            //Makes LIA auto measure.

        }

        //Setting DAC1 (Bias voltage)
        private void button1_Click(object sender, EventArgs e)
        {

            double voltage = Convert.ToDouble(biasvoltage.Text);

            //Maximum value is restricted to 12V, hence these statements:
            if (voltage > 12)
            {
                biasvoltage.Text = "12";
            }

            else if (voltage < -12)
            {
                biasvoltage.Text = "-12";
            }

            else
            {
                biasvoltage.Text = Convert.ToString(voltage);
            }

            string command = "DAC.1 " + biasvoltage.Text + "\n";
            lockinwrite(command);
            //Makes LIA change bias voltage.

        }

        //Reading back magnitude
        private void readmag_Click(object sender, EventArgs e)
        {

            //Ref in frequency:
            lockinwrite("IE 2\n");

            //Checkbox relates to autosensitivity:
            if (checkBox1.Checked)
            {
                lockinwrite("AS\n");
            }

            mag.Text = Readback();

        }

        //SWEEP!
        private void Sweep_Click(object sender, EventArgs e)
        {

            //Checking that file output is specified:
            if (filename.Text == "")
            {
                MessageBox.Show("Please include a filename in the Data Output tab");
                return;
            }
            if (Location.Text == "")
            {
                MessageBox.Show("Please include a file location in the Data Output tab");
                return;
            }

            if (File.Exists(Location.Text + "\\" + filename.Text + ".txt"))
            {
                MessageBox.Show("There exists a file with an identical name in this location already!");
                return;
            }

            //Checking that monochromator is calibrated:
            if (MCcurrentdial.Text == "Enter Value")
            {
                MessageBox.Show("Enter value!\r\n");
                //Pop-up box prompting user to enter dial reading.
                return;
            }

            //Sweep parameters
            double startpoint = Convert.ToDouble(sweepstart.Text);
            double endpoint = Convert.ToDouble(sweepend.Text);
            string startunit = Convert.ToString(sweepstartunit.SelectedItem);
            string endunit = Convert.ToString(sweependunit.SelectedItem);

            //Checking that sweep range is within allowed values:
            double dummy1;
            double dummy2;

            if (endpoint < startpoint)
            {

                dummy1 = startpoint;
                dummy2 = endpoint;
                endpoint = dummy1;
                startpoint = dummy2;
                sweepstart.Text = Convert.ToString(startpoint);
                sweepend.Text = Convert.ToString(endpoint);

            }

            else if (endpoint == startpoint)
            {
                return;
            }

            //Make sure all sweep units are in 'Dial':
            switch (startunit)
            {
                case "Wavelength (nm)":
                    startpoint = wtod(startpoint);
                    break;
                case "Dial":
                    break;
            }

            switch (endunit)
            {
                case "Wavelength (nm)":
                    endpoint = wtod(endpoint);
                    break;
                case "Dial":
                    break;
            }

            //Calculating corressponding wavelength:
            corowave(sender, e);
            //Goes to corowave function!

            //Number of steps and interval:
            int nofsteps = Convert.ToInt16(steps.Text);
            double interval = Convert.ToDouble(numericUpDown1.Value);

            //Applying settings to lock-in amplifier:
            button3_Click(sender, e);
            getfrequency_Click(sender, e);

            //Preparing for the while loop:

            //Variables
            int counter = 1;
            double dial = startpoint;
            double response = 0.0;
            double stime;
            int stimeint;
            int filtercmd;

            //Setting monochromator to sweep start point:
            MCnewsetting.Text = Convert.ToString(startpoint);
            automotorspeed.SelectedItem = "400";
            autounits.SelectedItem = "Dial";
            stime = 70 * (startpoint - Convert.ToDouble(MCcurrentdial.Text));
            //stime is used to work out a suitable sleep time,
            //At speed 100, the motor cycled through 300 dial units in 60 seconds,
            //Thus it takes 200ms per dial unit.

            MC_autoset_click(sender, e);

            if (stime < 0)
            {
                stime = -stime;
            }

            stimeint = Convert.ToInt16(stime);
            Thread.Sleep(stimeint);
            //Sleep time as a function of dial units.

            //Time to wait between resetting monochromator position during sweep:
            stime = Convert.ToDouble(interval) * 250;
            stimeint = Convert.ToInt16(stime);
            motorspeed.SelectedItem = "100";
            MCmanunit.SelectedItem = "Dial";


            //Initialising an output file:
            FileInfo fi = new FileInfo(Location.Text + "\\" + filename.Text + ".txt");
            TextWriter tw = fi.CreateText();
            tw.Write(
                        hdate.Text + "\r\n" +
                        huser.Text + "\r\n" +
                        hsample.Text + "\r\n" +
                        hcomments.Text + "\r\n" +
                        "\r\n" +
                        "Lock-in Amplifier settings:" + "\r\n" +
                        "Filter time constant: " + "\t" + filtertc.Text + "\r\n" +
                        "Measurement made from: " + "\t" + input.Text + "\r\n" +
                        "Bias voltage (Volts): " + "\t" + biasvoltage.Text + "\r\n" +
                        "Line frequency rejection: " + "\t" + linefilter.Text + "\r\n" +
                        "Chopper frequency (Hz): " + referencefrequency.Text + "\r\n" +
                        "\r\n" +
                        "Sweep settings: " + "\r\n" +
                        "Start point (" + sweepstartunit.SelectedItem + "): "
                            + "\t" + sweepstart.Text + "\r\n" +
                        "End point (" + sweependunit.SelectedItem + "): "
                            + "\t" + sweepend.Text + "\r\n" +
                        "Total number of steps: " + "\t" + steps.Text + "\r\n" +
                        "Step interval (Dial Units): " + "\t" + numericUpDown1.Value + "\r\n" +
                        "\r\n" +
                        "Step" + "\t" + "Wavelength (nm)" + "\t" + "Dial reading"
                            + "\t" + input.Text + "\t" + "Filter" + "\r\n"
                        );

            //While loop:
            while (counter < nofsteps + 1)
            {

                //Set Filter if Auto-set selected
                if (engagefilters.Checked)
                {
                    filtercmd = checkfilter(Convert.ToDouble(MCcurrentdial.Text));

                    if (filtercmd == 0)
                    {
                        newfilter.SelectedItem = Filter1;
                    }

                    else if (filtercmd == 1)
                    {
                        newfilter.SelectedItem = Filter5;
                    }

                    else if (filtercmd == 2)
                    {
                        newfilter.SelectedItem = Filter4;
                    }

                    else if (filtercmd == 3)
                    {
                        newfilter.SelectedItem = Filter3;
                    }

                    else if (filtercmd == 4)
                    {
                        newfilter.SelectedItem = Filter2;
                    }

                    set_filter(sender, e);

                }

                //Take reading:
                readmag_Click(sender, e);
                resp.Text = mag.Text;
                response = Convert.ToDouble(mag.Text);

                Application.DoEvents();
                this.Refresh();

                //Write measurement back to program and output file:
                currwave.Text = Convert.ToString(dtow(dial));
                stepnum.Text = Convert.ToString(counter);
                tw.Write(stepnum.Text + "\t");
                tw.Write(currwave.Text + "\t");
                tw.Write(MCcurrentdial.Text + "\t");
                tw.Write(Convert.ToString(response) + "\t");
                tw.Write(currentfilter.Text + "\r\n");
                //tw.Write(noise + "\r\n");


                Application.DoEvents();
                this.Refresh();

                //Adjust monochromator for next loop:
                if (safetycheck(interval + Convert.ToDouble(MCcurrentdial.Text)) == 1)
                {
                    stopbutton_Click(sender, e);
                }
                ;
                chanAStep.Text = Convert.ToString(interval);
                wavelength_up_Click(sender, e);
                dial = dial + Convert.ToDouble(interval);
                Thread.Sleep(stimeint);

                counter = counter + 1;

                Application.DoEvents();
                this.Refresh();

                //Check if the user wants to end the loop
                if (stopbuttonchar == 1)
                {

                    counter = nofsteps + 2;
                    //This is the stop botton feature.

                }

            }
            //End of while loop

            //Reset Stop condition to false:
            stopbuttonchar = 0;

            //Close output file:
            tw.Close();

            //Reset filter to position 1:
            newfilter.SelectedItem = Filter1;
            set_filter(sender, e);

            //Display that sweep is complete:
            resp.Text = "Sweep complete";


        }

        //Coressponding wavelength function
        private void corowave(object sender, EventArgs e)
        {

            double dialinterval = Convert.ToDouble(numericUpDown1.Value);
            dialinterval = dialinterval * 1800 / Convert.ToDouble(grating.Text);
            if (dialinterval < 0)
            {
                dialinterval = -dialinterval;
            }
            corowave1.Text = Convert.ToString(dialinterval) + " nm";

            string a = sweepstart.Text;
            string b = sweepend.Text;

            if (a == "")
            {
                return;
            }

            else if (b == "")
            {
                return;
            }


            double interval = Convert.ToDouble(numericUpDown1.Value);
            int nofsteps;
            double startpoint = Convert.ToDouble(sweepstart.Text);
            string unit1 = Convert.ToString(sweepstartunit.SelectedItem);

            switch (unit1)
            {

                case "Wavelength (nm)":
                    startpoint = wtod(startpoint);
                    break;
                case "Dial":
                    break;
                //To see if a conversion between dial and wavelength values is needed.

            }


            double endpoint = Convert.ToDouble(sweepend.Text);
            string unit2 = Convert.ToString(sweependunit.SelectedItem);

            switch (unit2)
            {

                case "Wavelength (nm)":
                    endpoint = wtod(endpoint);
                    break;
                case "Dial":
                    break;
                //To see if a conversion between dial and wavelength values is needed.

            }

            double dummy3 = (endpoint - startpoint) / interval;
            nofsteps = Convert.ToInt16(dummy3);

            if (nofsteps < 0)
            {

                nofsteps = -nofsteps;

            }

            steps.Text = Convert.ToString(nofsteps);

        }

        //Opening up the browser dialogue box
        private void button6_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                Location.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        //Converting LIA string to a 8 digit number
        private string correctbyte(string orig)
        {

            //If string is too short, must add zeros.
            int length = orig.Length;

            if (length < 2)
            {
                orig = "0000000" + orig;
            }

            else if (length < 3)
            {
                orig = "000000" + orig;
            }

            else if (length < 4)
            {
                orig = "00000" + orig;
            }

            else if (length < 5)
            {
                orig = "0000" + orig;
            }

            else if (length < 6)
            {
                orig = "000" + orig;
            }

            else if (length < 7)
            {
                orig = "00" + orig;
            }

            else if (length < 8)
            {
                orig = "0" + orig;
            }

            else if (length == 8)
            {
                orig = orig;
            }

            return orig;
            //Returns an 8digit binary number between 0 and 255

        }

        //Checking that LIA is ready
        private void areyouready(string command)
        {

            SerialPollFlags temp;
            temp = LIA.SerialPoll();
            string test2 = Convert.ToString(Convert.ToInt16(temp), 2);

            //Getting the digit into 8 digit format:
            test2 = correctbyte(test2);

            Debug.WriteLine("Are You Ready?");
            Debug.WriteLine("Command = " + command);
            Debug.WriteLine("Serial Poll = " + test2);

            while (test2[7] == '0')
            {
                temp = LIA.SerialPoll();
                test2 = Convert.ToString(Convert.ToInt16(temp), 2);
                test2 = correctbyte(test2);

                if ((Convert.ToUInt16(temp) & 128) == 128)
                {

                    break;

                }

                Application.DoEvents();

                Debug.WriteLine("Are You Ready?");
                Debug.WriteLine("Command = " + command);
                Debug.WriteLine("Serial Poll = " + test2);

            }

            Debug.WriteLine("Ready for " + command);
            //(Debug functions allow for problem solving within this program builder)
        }

        //Checking that LIA is finished
        private void areyoufinished(string command)
        {

            SerialPollFlags temp;
            temp = LIA.SerialPoll();
            string test2 = Convert.ToString(Convert.ToInt16(temp), 2);

            //Getting the digit into 8 digit format:
            test2 = correctbyte(test2);

            Debug.WriteLine("Are You Finished?");
            Debug.WriteLine("Command = " + command);
            Debug.WriteLine("Serial Poll = " + test2);

            while (test2[7] == '0')
            {
                temp = LIA.SerialPoll();
                test2 = Convert.ToString(Convert.ToInt16(temp), 2);
                test2 = correctbyte(test2);

                if ((Convert.ToUInt16(temp) & 128) == 128)
                {

                    break;

                }

                Application.DoEvents();

                Debug.WriteLine("Are You Finished?");
                Debug.WriteLine("Command = " + command);
                Debug.WriteLine("Serial Poll = " + test2);

            }
            Debug.WriteLine("Command: " + command + " complete");

            if (test2[4] == '1')
            {

                MessageBox.Show("No reference frequency detected");
                return;

            }

        }

        //Writing to the lock-in amplifier
        private void lockinwrite(string command)
        {

            //areyouready(command); is not needed here.
            LIA.Write(command);
            areyoufinished(command);
            //This function writes and then checks that the LIA is finished.

        }

        //Readback function including sleep times
        private string Readback()
        {

            string tc = Convert.ToString(filtertc.SelectedItem);
            if (tc == "10μs")
            {
                Thread.Sleep(100);
            }

            else if (tc == "20μs")
            {
                Thread.Sleep(100);
            }

            else if (tc == "40μs")
            {
                Thread.Sleep(100);
            }

            else if (tc == "80μs")
            {
                Thread.Sleep(100);
            }

            else if (tc == "160μs")
            {
                Thread.Sleep(100);
            }

            else if (tc == "320μs")
            {
                Thread.Sleep(100);
            }

            else if (tc == "640μs")
            {
                Thread.Sleep(100);
            }

            else if (tc == "5ms")
            {
                Thread.Sleep(100);
            }

            else if (tc == "10ms")
            {
                Thread.Sleep(100);
            }

            else if (tc == "20ms")
            {
                Thread.Sleep(100);
            }

            else if (tc == "50ms")
            {
                Thread.Sleep(250);
            }

            else if (tc == "100ms")
            {
                Thread.Sleep(1000);
            }

            else if (tc == "200ms")
            {
                Thread.Sleep(3000);
            }

            else if (tc == "500ms")
            {
                Thread.Sleep(3000);
            }

            else if (tc == "1s")
            {
                Thread.Sleep(3000);
            }

            else if (tc == "2s")
            {
                Thread.Sleep(3000);
            }

            else if (tc == "5s")
            {
                Thread.Sleep(6000);
            }

            else if (tc == "10s")
            {
                Thread.Sleep(11000);
            }

            else if (tc == "20s")
            {
                Thread.Sleep(21000);
            }

            else if (tc == "50s")
            {
                Thread.Sleep(51000);
            }

            else if (tc == "100s")
            {
                Thread.Sleep(11000);
            }

            else if (tc == "200s")
            {
                Thread.Sleep(201000);
            }

            else if (tc == "500s")
            {
                Thread.Sleep(501000);
            }

            else if (tc == "1ks")
            {
                Thread.Sleep(1001000);
            }

            else if (tc == "2ks")
            {
                Thread.Sleep(2001000);
            }

            else if (tc == "5ks")
            {
                Thread.Sleep(5001000);
            }

            else if (tc == "10ks")
            {
                Thread.Sleep(10001000);
            }

            else if (tc == "20ks")
            {
                Thread.Sleep(20001000);
            }

            else if (tc == "50ks")
            {
                Thread.Sleep(50001000);
            }

            else if (tc == "100ks")
            {
                Thread.Sleep(100001000);
            }

            lockinwrite("MAG. \n");
            Thread.Sleep(500);
            return LIA.ReadString();

        }

        //Stop button
        private void stopbutton_Click(object sender, EventArgs e)
        {

            stopbuttonchar = 1;

        }

        //Auto selecting filters
        private int checkfilter(double dial)
        {

            //Boundaries
            double b0 = wtod(400);
            double b1 = wtod(700);
            double b2 = wtod(1200);
            double b3 = wtod(2000);
            //These can be changed according to the filters installed.

            if (dial <= b0)
            {
                return 0;
            }

            else if (dial <= b1)
            {
                return 1;
            }

            else if (dial <= b2)
            {
                return 2;
            }

            else if (dial <= b3)
            {
                return 3;
            }
            else if (dial > b3)
            {
                return 4;
            }
            else
            {
                return 99;
                //Error message!
            }

        }

        //Upper and lower monochromator safety bounds
        private int safetycheck(double newsetting)
        {
            string units = Convert.ToString(autounits.SelectedItem);
            double upperlimit = 888;
            double lowerlimit = 001;
            int message = 0;

            if (newsetting >= upperlimit)
            {
                if (units == "Dial")
                {
                    MessageBox.Show("Requested monochromator setting is too high");
                    message = 1;
                }

            }

            else if (newsetting <= lowerlimit)
            {

                MessageBox.Show("Requested monochromator setting is too low");
                message = 1;

            }
            //These prevent the monochromator from scrolling through zero and thus prevents damage.

            return message;
        }

        private void IV_Click(object sender, EventArgs e)
        {

            //Checking that file output is specified:
            if (filename.Text == "")
            {
                MessageBox.Show("Please include a filename in the Data Output tab");
                return;
            }
            if (Location.Text == "")
            {
                MessageBox.Show("Please include a file location in the Data Output tab");
                return;
            }

            if (File.Exists(Location.Text + "\\" + filename.Text + ".txt"))
            {
                MessageBox.Show("There exists a file with an identical name in this location already!");
                return;
            }


            //Sweep parameters
            double startpoint = Convert.ToDouble(stv.Text);
            double endpoint = Convert.ToDouble(ev.Text);
            double step = Convert.ToDouble(vstep.Text);

            //Checking that sweep range is within allowed values:
            double dummy1;
            double dummy2;

            if (endpoint < startpoint)
            {

                dummy1 = startpoint;
                dummy2 = endpoint;
                endpoint = dummy1;
                startpoint = dummy2;
                sweepstart.Text = Convert.ToString(startpoint);
                sweepend.Text = Convert.ToString(endpoint);

            }

            else if (endpoint == startpoint)
            {
                return;
            }

            //Number of steps and interval:
            int nofsteps;
            nofsteps = Convert.ToInt16((endpoint - startpoint) / step);


            //Variables
            int counter = 1;
            double response = 0.0;
            double stime;
            int stimeint;
            int filtercmd;


            //Initialising an output file:
            FileInfo fi = new FileInfo(Location.Text + "\\" + filename.Text + ".txt");
            TextWriter tw = fi.CreateText();
            tw.Write(
                        hdate.Text + "\r\n" +
                        huser.Text + "\r\n" +
                        hsample.Text + "\r\n" +
                        hcomments.Text + "\r\n" +
                        "\r\n" +
                        "IV Data" + "\r\n" + "\r\n" +
                        "Lock-in Amplifier settings:" + "\r\n" +
                        "Filter time constant: " + "\t" + filtertc.Text + "\r\n" +
                        "Measurement made from: " + "\t" + input.Text + "\r\n" +
                        "Line frequency rejection: " + "\t" + linefilter.Text + "\r\n" +
                        "Chopper frequency (Hz): " + referencefrequency.Text + "\r\n" +
                        "\r\n" +
                        "Bias Voltage (DAC1)" + "\t" + input.Text + "\r\n"
                        );

            biasvoltage.Text = stv.Text;
            button1_Click(sender, e);
            Thread.Sleep(500);

            //While loop:
            while (counter < nofsteps + 1)
            {

                //Take reading:
                readmag_Click(sender, e);
                response = Convert.ToDouble(mag.Text);

                Application.DoEvents();
                this.Refresh();

                //Write measurement back to program and output file:
                tw.Write(biasvoltage.Text + "\t");
                tw.Write(Convert.ToString(response) + "\t" + "\r\n");


                Application.DoEvents();
                this.Refresh();

                biasvoltage.Text = Convert.ToString(Convert.ToDouble(biasvoltage.Text) + step);
                button1_Click(sender, e);
                Thread.Sleep(500);

                counter = counter + 1;

                Application.DoEvents();
                this.Refresh();

                //Check if the user wants to end the loop
                if (stopbuttonchar == 1)
                {

                    counter = nofsteps + 2;
                    //This is the stop botton feature.

                }

            }
            //End of while loop

            //Reset Stop condition to false:
            stopbuttonchar = 0;

            //Close output file:
            tw.Close();

        }

        private void twodimension_Click(object sender, EventArgs e)
        {
            //Checking that file output is specified:
            if (filename.Text == "")
            {
                MessageBox.Show("Please include a filename in the Data Output tab");
                return;
            }
            if (Location.Text == "")
            {
                MessageBox.Show("Please include a file location in the Data Output tab");
                return;
            }

            if (File.Exists(Location.Text + "\\" + filename.Text + ".txt"))
            {
                MessageBox.Show("There exists a file with an identical name in this location already!");
                return;
            }


            //Sweep parameters
            double startpoint = Convert.ToDouble(stv.Text);
            double endpoint = Convert.ToDouble(ev.Text);
            double step = Convert.ToDouble(vstep.Text);

            //Checking that sweep range is within allowed values:
            double dummy1;
            double dummy2;

            if (endpoint < startpoint)
            {

                dummy1 = startpoint;
                dummy2 = endpoint;
                endpoint = dummy1;
                startpoint = dummy2;
                sweepstart.Text = Convert.ToString(startpoint);
                sweepend.Text = Convert.ToString(endpoint);

            }

            else if (endpoint == startpoint)
            {
                return;
            }

            //Number of steps and interval:
            int nofsteps;
            nofsteps = Convert.ToInt16((endpoint - startpoint) / step);


            //Variables
            int counter = 1;
            double response = 0.0;
            double stime;
            int stimeint;
            int filtercmd;

            biasvoltage.Text = stv.Text;
            button1_Click(sender, e);
            Thread.Sleep(500);

            String seriesname = filename.Text;
            filename.Text = seriesname + biasvoltage.Text;

            //While loop:
            while (counter < nofsteps + 1)
            {
                Sweep_Click(sender, e);

                Application.DoEvents();
                this.Refresh();

                biasvoltage.Text = Convert.ToString(Convert.ToDouble(biasvoltage.Text) + step);
                button1_Click(sender, e);
                Thread.Sleep(500);

                filename.Text = seriesname + biasvoltage.Text;

                counter = counter + 1;

                Application.DoEvents();
                this.Refresh();

                //Check if the user wants to end the loop
                if (stopbuttonchar == 1)
                {

                    counter = nofsteps + 2;
                    //This is the stop botton feature.

                }

            }
            //End of while loop

            //Reset Stop condition to false:
            stopbuttonchar = 0;

        }

    }

}
