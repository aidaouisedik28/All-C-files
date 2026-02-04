 if (Process.GetProcessesByName("HD-Player").Length == 0)
{
    //Type Here Emulator not found Status
    Console.Beep(240, 300);
}
else
{
    //Type Here Waiting Status
        RIG.Text = "Applying";

    string search = "Scan";
    string replace = "Reap";

    bool k = false;
    MEM.OpenProcess("HD-Player");

    int i2 = 22000000;
    IEnumerable<long> wl = await MEM.AoBScan(search, writable: true, true);
    string u = "0x" + wl.FirstOrDefault().ToString("X");
    if (wl.Count() != 0)
    {
        for (int i = 0; i < wl.Count(); i++)
        {
            i2++;
            MEM.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
        }
        k = true;
    }

    if (k == true)
    {
        Console.Beep(400, 300);
        //Type Here Code Inject Success Status
        sta.Text = "Inject";    
    }
    else
    {
        //Type Here Code Inject Faild Status
        Console.Beep(240, 300);
        RIG.Text = "Failed";
    }
} 
