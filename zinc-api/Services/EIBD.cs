using zinc_api.Models.Entities;
using zinc_api.Models.Input;
using zinc_api.Services.Interfaces;

namespace zinc_api.Services
{
    public class EIBD : IEIBD
    {
        private readonly AppDbContext ctx;

        public EIBD(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<OBG2> Create(In_EIBD newEIBD)
        {
            var res = await ctx.obg2.AddAsync(newEIBD.AutoMap<In_EIBD, OBG2>());
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public Task<HVP> CreateHVP(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<KEC_Kadmievoe> CreateKADMIEVOE(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<KEC1> CreateKEC1(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<KEC2> CreateKEC2(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<Velc_KVP5> CreateKVP5(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<Velc_KVP6> CreateKVP6(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<GMC_Larox> CreateLAROX(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<OBG1> CreateOBG1(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<SKC1> CreateSKC1(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<SKC2> CreateSKC2(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<GMC_Velc1> CreateVELC1(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<GMC_Velc2> CreateVELC2(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<Vysh> CreateVYSH(In_EIBD newEIBD)
        {
            throw new NotImplementedException();
        }

        public Task<HVP> GetHVP(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<KEC_Kadmievoe> GetKADMIEVOE(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<KEC1> GetKEC1(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<KEC2> GetKEC2(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<Velc_KVP5> GetKVP5(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<Velc_KVP6> GetKVP6(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<GMC_Larox> GetLAROX(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<OBG1> GetOBG1(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<OBG2> GetOBG2(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<SKC1> GetSKC1(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<SKC2> GetSKC2(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<GMC_Velc1> GetVELC1(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<GMC_Velc2> GetVELC2(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<Vysh> GetVYSH(DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
