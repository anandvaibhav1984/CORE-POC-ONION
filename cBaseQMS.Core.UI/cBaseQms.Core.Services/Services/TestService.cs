using AutoMapper;
using cBaseQms.Core.Repositry.Infrastructure;
using cBaseQms.Core.Repositry;
using cBaseQms.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using cBaseQMS.Core.DAL.Models;
using cBaseQms.Core.Repositry.Repositories;

namespace cBaseQms.Core.Services.Services
{
    // operations you want to expose
    public interface ITestService
    {
        IEnumerable<TestsViewModel> GetAllTests(string name = null);
        IEnumerable<TestsViewModel> GetAllTestByTestMasterID(int testMasterId,string active);
      //  bool ShiftSequence(int currentKeyID, int nextKeyID, int prevKeyID, string opCode,int testMasterId);
        Tests GetTest(int id);
        Tests GetTest(string name);
        bool CreateTest(TestsViewModel test);
        void SaveTest();
      //  bool RemoveFromTestMaster(TestsViewModel testsViewModel);
      //  bool UpdateTest(TestsViewModel testsViewModel);
      //  bool MoveTest(TestsViewModel testsViewModel, int TestMasterIdFrom);

    }
    public class TestService : ITestService
    {
        private readonly ITestRepository testRepository;        
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IMapper _iMapper;
        public TestService(ITestRepository testRepository, IUnitOfWork _iUnitOfWork, IMapper _iMapper)
        {   
            this.testRepository = testRepository;
            this._iUnitOfWork = _iUnitOfWork;
            this._iMapper = _iMapper;

        }

        public bool CreateTest(TestsViewModel testsViewModel)
        { 
            Tests test;
            IEnumerable<TestsViewModel> testsViewModelList;
            testsViewModelList = GetAllTestByTestMasterID(testsViewModel.TestMasterID,"true");
            int maxSequence = testsViewModelList.Count() > 0 ?testsViewModelList.Max(o => o.Sequence)+1:1;
            testsViewModel.Sequence = maxSequence;
            test = _iMapper.Map<TestsViewModel, Tests>(testsViewModel);

            testRepository.Add(test);
          //  throw new Exception("this is ex");
            SaveTest();
           
            return test.TestId > 0;
            
        }

        public IEnumerable<TestsViewModel> GetAllTestByTestMasterID(int testMasterId, string active)
        {
            IEnumerable<TestsViewModel> testsViewModel;
            IEnumerable<Tests> test;
            bool objActive;
            if (Boolean.TryParse(active,out objActive))
            {
                test = testRepository.GetAll().Where(c => c.TestMasterId == testMasterId && c.IsActive== objActive).OrderBy(e=>e.Sequence).ToList();
            }
            else
                test = testRepository.GetAll().Where(c => c.TestMasterId == testMasterId ).OrderBy(e => e.Sequence).ToList();
            testsViewModel = _iMapper.Map<IEnumerable<Tests>, IEnumerable<TestsViewModel>>(test);
            return testsViewModel;
        }

        public IEnumerable<TestsViewModel> GetAllTests(string name = null)
        {
            IEnumerable<TestsViewModel> testsViewModel;
            IEnumerable<Tests> test;
            
            if (string.IsNullOrEmpty(name))
                test = testRepository.GetAll().ToList();
            else
                test = testRepository.GetAll().Where(c => c.TestName== name).ToList();

            testsViewModel = _iMapper.Map<IEnumerable<Tests>, IEnumerable<TestsViewModel>>(test);
            return testsViewModel;
        }

        public Tests GetTest(int id)
        {
            throw new NotImplementedException();
        }

        public Tests GetTest(string name)
        {
            var test = testRepository.GetTests(name);
            return test;
        }

        //public bool MoveTest(TestsViewModel testsViewModel, int TestMasterIdFrom)
        //{

        //    this.CreateTest(testsViewModel);
          
        //    testsViewModel.TestID = TestMasterIdFrom;
        //    Tests test;
        //    test = _iMapper.Map<TestsViewModel, Tests>(testsViewModel);
        //    testRepository.Update(test, o => o.IsActive, o => o.ModifiedBy, o => o.ModifiedOn);
        //    SaveTest();
        //    return true;

        //}

        //public bool RemoveFromTestMaster(TestsViewModel testsViewModel)
        //{
        //    Tests test;
        //    test = _iMapper.Map<TestsViewModel, Tests>(testsViewModel);
        //    testRepository.Update(test, o => o.IsActive, o => o.ModifiedBy, o => o.ModifiedOn);
        //    SaveTest();
        //    return true;
        //}

        //public bool UpdateTest(TestsViewModel testsViewModel)
        //{
        //    Tests test;
        //    test = _iMapper.Map<TestsViewModel, Tests>(testsViewModel);
        //    testRepository.Update(test, o => o.TestName, o => o.IsActive, o => o.ModifiedBy, o => o.ModifiedOn);
        //    SaveTest();
        //    return true;
        //}

        public void SaveTest()
        {
            _iUnitOfWork.Commit();
        }

        //public bool ShiftSequence(int currentKeyID, int nextKeyID, int prevKeyID, string opCode, int testMasterId)
        //{
        //    IEnumerable<Tests> test;
        //    test = testRepository.GetAll().Where(c => c.TestMasterId == testMasterId).OrderBy(e => e.Sequence).ToList();
        //    if (opCode == "UP" && prevKeyID>0)
        //    {
        //        var currentTest = test.Where(x => x.TestId == currentKeyID).FirstOrDefault();
        //        currentTest.Sequence = test.Where(x => x.TestId == currentKeyID).Select(s => s.Sequence).FirstOrDefault() - 1;
        //        testRepository.Update(currentTest, o => o.Sequence);

        //        var previousTest = test.Where(x => x.TestId == prevKeyID).FirstOrDefault();
        //        previousTest.Sequence = test.Where(x => x.TestId == prevKeyID).Select(s => s.Sequence).FirstOrDefault() + 1;
        //        testRepository.Update(previousTest, o => o.Sequence);
        //        SaveTest();

        //    }

        //    else if (opCode == "DW" && nextKeyID>0)
        //    {
        //        var currentTest = test.Where(x => x.TestID == currentKeyID).FirstOrDefault();
        //        currentTest.Sequence = test.Where(x => x.TestID == currentKeyID).Select(s => s.Sequence).FirstOrDefault() +1;
        //        testRepository.Update(currentTest, o => o.Sequence);

        //        var previousTest = test.Where(x => x.TestID == nextKeyID).FirstOrDefault();
        //        previousTest.Sequence = test.Where(x => x.TestID == nextKeyID).Select(s => s.Sequence).FirstOrDefault() - 1;
        //        testRepository.Update(previousTest, o => o.Sequence);
        //        SaveTest();

        //    }
        //    return true;
        //}
    }
}
