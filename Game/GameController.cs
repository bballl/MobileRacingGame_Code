﻿using Company.Project.ContentData;
using Company.Project.Features.Abilities;
using Company.Project.Features.Inventory;
using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Tools;
using UnityEngine;

namespace Game
{
    public class GameController : BaseController
    {
        #region Life cycle
        
        public GameController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();
            var tapeBackgroundController =
                new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddControllers(tapeBackgroundController);
            var inputGameController =
                new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddControllers(inputGameController);
            var carController = new CarController();
            AddControllers(carController);

            // можно внедрить как зависимость для другого контроллера
            var abilityController = ConfigureAbilityController(placeForUi, carController);
        }

        #endregion

        #region Methods

        private IAbilitiesController ConfigureAbilityController(
            Transform placeForUi,
            IAbilityActivator abilityActivator)
        {
            var abilityItemsConfigCollection 
                = ContentDataSourceLoader.LoadAbilityItemConfigs(new ResourcePath {PathResource = "DataSource/Ability/AbilityItemConfigDataSource"});
            var abilityRepository 
                = new AbilityRepository(abilityItemsConfigCollection);
            var abilityCollectionViewPath 
                = new ResourcePath {PathResource = $"Prefabs/{nameof(AbilityCollectionView)}"};
            var abilityCollectionView 
                = ResourceLoader.LoadAndInstantiateObject<AbilityCollectionView>(abilityCollectionViewPath, placeForUi, false);
            AddGameObjects(abilityCollectionView.gameObject);
            
            // загрузить в модель экипированные предметы можно любым способом
            var inventoryModel = new InventoryModel();
            var abilitiesController = new AbilitiesController(abilityRepository, inventoryModel, abilityCollectionView, abilityActivator);
            AddControllers(abilitiesController);
            
            return abilitiesController;
        }

        #endregion
    }
}

