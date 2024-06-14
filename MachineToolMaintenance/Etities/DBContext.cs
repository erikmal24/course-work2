namespace MachineToolMaintenance.Etities
{
    public partial class MachineToolMaintenanceEntities
    {
        private static MachineToolMaintenanceEntities _context;
        public static MachineToolMaintenanceEntities GetContext()
        {
            if (_context == null)
                _context = new MachineToolMaintenanceEntities();
            return _context;
        }
    }
}
