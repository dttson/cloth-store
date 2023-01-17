# The Clothes Store

# Introduction

This the sample simulation of the clothes stores, where the character can moving around meet the shopkeeper to buy clothes. The game view is top-down like Stardew Valley game.

# How to play

- Use `W` `A` `S` `D` to move up, down, left and right
- The character can’t move outside of the screen
- When character hit the shopkeeper (who is standing at right of the screen), the shop UI will open and show all the clothes that are on sale.
- The shop contains many clothes items, each item has its own price in coin unit. To wear anything, user need to buy them first (by clicking on `+` button), then choose it to preview it on character on the left side.
- At the beginning, character has default outfit (1 shirt and 1 pants) and balance of 1000 coins. Then you can either sell the default (to earn more money) or buy more outfits.

# Technologies

- Unity 2021.3.2f1
- Unity Sprite Skinning & Animation (for swapping outfits and animating character)
- Physics 2D (RigidBody2D, BoxCollider)
- Unity Autolayout: Horizontal / Vertical / Grid Layout (for shop UI)

# Features

- Character Moving Controller
- Outfit Controller
- Animation Controller for moving up/down (left/right using the same animation)
- Shop features: buy / sell outfit items, equip items.

# Known Issues & Limitation

- Animation of horizontal movement need to be changed.
- The background scene of the shop is quite plain (due to time limitation)
- The shopkeeper doesn’t have animation
- There is no conversation before open shop UI
- Sometimes user can sell the last outfit (which should not be allowed)
- The UI layout is not good on some resolutions

# Release
- https://github.com/dttson/cloth-store/blob/45673a6b0b36e72141565dfa83bb7fc369bd8082/Release/ClothesStore_Sample.zip

# Documentation (PDF)
- https://github.com/dttson/cloth-store/blob/45673a6b0b36e72141565dfa83bb7fc369bd8082/README.pdf
