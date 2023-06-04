using zinc_api.Models.Entities;
using zinc_api.Models.Input;

namespace zinc_api.Services.Interfaces
{
    public interface IEIBD
    {
        public Task<KEC1> CreateKEC1(In_EIBD newEIBD);
        public Task<KEC1> GetKEC1(DateOnly date);
        public Task<KEC2> CreateKEC2(In_EIBD newEIBD);
        public Task<KEC2> GetKEC2(DateOnly date);
        public Task<KEC_Kadmievoe> CreateKADMIEVOE(In_EIBD newEIBD);
        public Task<KEC_Kadmievoe> GetKADMIEVOE(DateOnly date);
        public Task<GMC_Velc1> CreateVELC1(In_EIBD newEIBD);
        public Task<GMC_Velc1> GetVELC1(DateOnly date);
        public Task<GMC_Velc2> CreateVELC2(In_EIBD newEIBD);
        public Task<GMC_Velc2> GetVELC2(DateOnly date);
        public Task<SKC1> CreateSKC1(In_EIBD newEIBD);
        public Task<SKC1> GetSKC1(DateOnly date);
        public Task<SKC2> CreateSKC2(In_EIBD newEIBD);
        public Task<SKC2> GetSKC2(DateOnly date);
        public Task<GMC_Larox> CreateLAROX(In_EIBD newEIBD);
        public Task<GMC_Larox> GetLAROX(DateOnly date);
        public Task<OBG1> CreateOBG1(In_EIBD newEIBD);
        public Task<OBG1> GetOBG1(DateOnly date);
        public Task<OBG2> Create(In_EIBD newEIBD);
        public Task<OBG2> GetOBG2(DateOnly date);
        public Task<Velc_KVP5> CreateKVP5(In_EIBD newEIBD);
        public Task<Velc_KVP5> GetKVP5(DateOnly date);
        public Task<Velc_KVP6> CreateKVP6(In_EIBD newEIBD);
        public Task<Velc_KVP6> GetKVP6(DateOnly date);
        public Task<Vysh> CreateVYSH(In_EIBD newEIBD);
        public Task<Vysh> GetVYSH(DateOnly date);
        public Task<HVP> CreateHVP(In_EIBD newEIBD);
        public Task<HVP> GetHVP(DateOnly date);
    }
}
