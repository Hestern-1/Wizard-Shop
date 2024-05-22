﻿using System;
using System.Collections.Generic;

namespace Assignment
{
    public class Character
    {
        // This is the list that manages the items in the characters inventory
        private List<Item> _inventoryList = new List<Item>();
        // This is the list that manages the hand items that are equipped to the character        
        private List<Item> _handItemList = new List<Item>();
        // This is the list that manages the clothing items that are equipped to the character
        private List<Item> _clothingList = new List<Item>();
        // This is the list that manages the spell items that are equipped to the character
        private List<Item> _spellList = new List<Item>();
        // Keeps track of the number of items equipped to each area of the character
        private int _numberLeftHandEquipped = 0;
        private int _numberRightHandEquipped = 0;
        private int _numberTwoHandEquipped = 0;
        private int _numberSpellsEquipped = 0;
        private int _numberClothingEquipped = 0;
        // Keeps track of the characters attributes
        private int _gold;
        private int _currentWeight;
        private int _cleaningMagic;
        private int _protectiveMagic;
        private int _maxWeight;


        public Character(int gold, int currentWeight, int cleaningMagic, int protectiveMagic, int maxWeight,
            int numberClothing, int numberSpells, int numberLeftHand, int numberRightHand, int numberTwoHand)
        {
            _gold = gold;
            _currentWeight = currentWeight;
            _cleaningMagic = cleaningMagic;
            _protectiveMagic = protectiveMagic;
            _maxWeight = maxWeight;
            _numberClothingEquipped = numberClothing;
            _numberSpellsEquipped = numberSpells;
            _numberLeftHandEquipped = numberLeftHand;
            _numberRightHandEquipped = numberRightHand;
            _numberTwoHandEquipped = numberTwoHand;
            // TODO - you should add the ability to set the gold and weight when creating the character
        }

        public List<Item> InventoryList { get { return _inventoryList; } }
        public List<Item> HandItemList { get { return _handItemList; } }
        public List<Item> ClothingList { get { return _clothingList; } }
        public List<Item> SpellList { get { return _spellList; } }
        public int NumberClothing { get { return _numberClothingEquipped; } }
        public int NumberSpells { get { return _numberSpellsEquipped; } }
        public int NumberLeftHand { get { return _numberLeftHandEquipped; } }
        public int NumberRightHand { get { return _numberRightHandEquipped; } }
        public int NumberTwoHand { get { return _numberTwoHandEquipped; } }
        public int Gold { get { return _gold; } }
        public int CurrentWeight { get { return _currentWeight; } }
        public int CleaningMagic { get { return _cleaningMagic; } }
        public int ProtectiveMagic { get { return _protectiveMagic; } }
        public int MaxWeight { get { return _maxWeight; } }

        // TODO: Check if the character has enough weight left to carry the given item.
        // If it is successful it should return true otherwise false
        public bool EnoughWeight(Item item)
        {
            if (_currentWeight + item.Weight <= _maxWeight)
            {
                return true;
            }
            return false;
        }

        // TODO: Check if the character has enough gold left to buy the item.
        // If it is successful it should return true otherwise false
        public bool EnoughGold(Item item)
        {
            if (_gold - item.Cost >= 0)
            {
                return true;
            }
            return false;
        }

        // TODO: Equip the character with a given item based on its type.
        // Either a left-hand, right-hand, two-hand, clothing or spell item.
        // This should add an item from the correct character’s list and remove it from the inventory.
        // If it is successful it should return true otherwise false.
        public bool EquipItem(Item item)
        {
            if (_inventoryList.Contains(item) && (EnoughWeight(item)))
            {
                switch (item.TypeOfItem)
                {
                    case ItemType.Clothing:
                        if (_numberClothingEquipped < 2)
                        {
                            _clothingList.Add(item);
                            _clothingList.Sort();
                            _numberClothingEquipped++;
                            break;
                        }
                        return false;

                    case ItemType.Spell:
                        if (_numberSpellsEquipped < 2)
                        {
                            _spellList.Add(item);
                            _spellList.Sort();
                            _numberSpellsEquipped++;
                            break;
                        }
                        return false;

                    case ItemType.LeftHand:
                        if ((_numberLeftHandEquipped == 0) && (_numberTwoHandEquipped == 0))
                        {
                            _handItemList.Add(item);
                            _handItemList.Sort();
                            _numberLeftHandEquipped++;
                            break;
                        }
                        return false;

                    case ItemType.RightHand:
                        if ((_numberRightHandEquipped == 0) && (_numberTwoHandEquipped == 0))
                        {
                            _handItemList.Add(item);
                            _handItemList.Sort();
                            _numberRightHandEquipped++;
                            break;
                        }
                        return false;

                    case ItemType.TwoHand:
                        if ((_numberTwoHandEquipped == 0) && (_numberLeftHandEquipped == 0) && (_numberRightHandEquipped == 0))
                        {
                            _handItemList.Add(item);
                            _handItemList.Sort();
                            _numberTwoHandEquipped++;
                            break;
                        }
                        return false;

                    default:
                        return false;
                }
                _currentWeight += item.Weight;
                _cleaningMagic += item.CleaningMagic;
                _protectiveMagic += item.ProtectiveMagic;
                _inventoryList.Remove(item);
                return true;
            }
            return false;
        }

        // TODO: Unequip an item from the character.
        // This should remove an item from the correct character’s list and add it to the inventory.
        // If it is successful it should return true otherwise false.
        public bool UnequipItem(Item item)
        {
            switch (item.TypeOfItem)
            {
                case ItemType.Clothing:
                    if (_clothingList.Contains(item))
                    {
                        _clothingList.Remove(item);
                        _numberClothingEquipped--;
                        break;
                    }
                    return false;

                case ItemType.Spell:
                    if (_spellList.Contains(item))
                    {
                        _spellList.Remove(item);
                        _numberSpellsEquipped--;
                        break;
                    }
                    return false;

                case ItemType.LeftHand:
                    if (_handItemList.Contains(item))
                    {
                        _handItemList.Remove(item);
                        _numberLeftHandEquipped--;
                        break;
                    }
                    return false;

                case ItemType.RightHand:
                    if (_handItemList.Contains(item))
                    {
                        _handItemList.Remove(item);
                        _numberRightHandEquipped--;
                        break;
                    }
                    return false;

                case ItemType.TwoHand:
                    if (_handItemList.Contains(item))
                    {
                        _handItemList.Remove(item);
                        _numberTwoHandEquipped--;
                        break;
                    }
                    return false;

                default:
                    return false;
            }
            _currentWeight -= item.Weight;
            _cleaningMagic -= item.CleaningMagic;
            _protectiveMagic -= item.ProtectiveMagic;
            _inventoryList.Add(item);
            _inventoryList.Sort();
            return true;
        }

        // TODO: This item should buy an item if the character has enough gold. 
        // It should then be added to the characters inventory list.
        // return true if successful, false otherwise.
        public bool BuyItem(Item item)
        {
            if (EnoughGold(item))
            {
                _gold -= item.Cost;
                return true;
            }
            return false;
        }

        // TODO: This should remove an item from the characters inventory list
        // If it is successful it should return true otherwise false
        public bool SellItem(Item item)
        {
            if (_inventoryList.Contains(item))
            {
                _gold += item.Cost;
                return true;
            }
            return false;
        }
    }
}