using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UI;

public class AllPlayerCollector : MonoBehaviour
{
    public string DBFileName = "";
    public string DBFolder = "DB";

    List<Card> cards = new List<Card>();
    List<Item> items = new List<Item>();
    List<Deck> player_deck = new List<Deck>(); 
    List<Card> player_card = new List<Card>();

    public Text nameText;
    public Text rareText;
    public Text levelText;
    public Text cardText;
    public Text ncardText;


    public Player player = new Player(1, "Desastre", 0, 0, 0);
    public Dictionary<int,Inventory> myinventory = new Dictionary<int, Inventory>();

    //public Inventory myinventory = new Inventory(1, 2, 0);

    public Dictionary<int, Mail> mymail = new Dictionary<int, Mail>();
    public Mail mailbox = new Mail(1, 1, "Welcome new player", "Lootbox", 5);

    public void OpenLootbox() //..............for put to lootbox button
    {
        Debug.Log("check myinventory " + myinventory[1].getAmount());

        int cid = UnityEngine.Random.Range(0, 8);


        Card theCard = cards[cid];

        nameText.text = theCard.getName();
        rareText.text = theCard.getGrade();
        levelText.text = theCard.getLevel().ToString();

        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);//...for insert card that random to deck menu
        adapter.insertDeck(player.Id,theCard.getCharacter_ID(), theCard.getLevel(), theCard.getHp(), theCard.getAtk(), theCard.getDef());
        adapter.disconnectDatabase();
        

    }
    
    public void onLoadfromDatabase()
        {
            SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
            IDataReader reader = adapter.select("character", "*");


            string name = "";
            int character_id = 0;
            int guntype_id = 0;
            int level = 0;
            string grade = "";
            int hp = 0;
            int atk = 0;
            int def = 0;

    

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i) == "character_id")
                    {
                        character_id = Convert.ToInt32(reader.GetValue(i));
                    }
                    if (reader.GetName(i) == "name")
                    {
                        name = "" + reader.GetValue(i);
                    }
                    if (reader.GetName(i) == "guntype_id")
                    {
                        guntype_id = Convert.ToInt32(reader.GetValue(i));
                    }
                    if (reader.GetName(i) == "level")
                    {
                        level = Convert.ToInt32(reader.GetValue(i));
                    }
                    if (reader.GetName(i) == "grade")
                    {
                        grade = "" + reader.GetValue(i);
                    }
                    if (reader.GetName(i) == "hp")
                    {
                        hp = Convert.ToInt32(reader.GetValue(i));
                    }
                    if (reader.GetName(i) == "atk")
                    {
                        atk = Convert.ToInt32(reader.GetValue(i));
                    }
                    if (reader.GetName(i) == "def")
                    {
                        def = Convert.ToInt32(reader.GetValue(i));
                    }
                }
                cards.Add(new Card(character_id, name, guntype_id, level, hp, atk, def, grade));
                //Debug.Log(cards);
            }


            adapter.disconnectDatabase();
    }

    public void onLoadDeckfromDatabase()
    {
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        IDataReader reader = adapter.select("deck", "*");


        int player_id = 0;
        int character_id = 0;
        int level = 0;
        int hp = 0;
        int atk = 0;
        int def = 0;



        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == "player_id")
                {
                    player_id = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "character_id")
                {
                    character_id = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "level")
                {
                    level = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "hp")
                {
                    hp = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "atk")
                {
                    atk = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "def")
                {
                    def = Convert.ToInt32(reader.GetValue(i));
                }
            }
            player_deck.Add(new Deck(player_id, character_id, level, hp, atk, def));
            Debug.Log(player_deck);
        }


        adapter.disconnectDatabase();
    }

    //List<Item> items = new List<Item>();
    public void addMailItem()//...............for mail get item button........
    {
        //Mailbox mails = new Mailbox (1,)
        Item theItem = new Item(1, "Lootbox"); 

        print("add item from mail");
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        
        player.Silver_coin = player.Silver_coin + 500;
        player.Diamond = player.Diamond + 6000;
        

        adapter.updatePlayerSilver(player.Silver_coin);
        adapter.updatePlayerDiamond(player.Diamond);
        if ( !myinventory.ContainsKey(theItem.getItem_ID())) {


            adapter.insertInvenItem(player.Id, theItem.getItem_ID(), 5);//.....???? feel something wrong
        }
        else
        {
            // update
            Inventory i = myinventory[theItem.getItem_ID()];
            i.setAmount(i.getAmount() + 5);
            // adapter.update.....
        }
        


        adapter.disconnectDatabase();

    }
    public void onLoadItemfromDatabase() ///item
    {
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        IDataReader reader = adapter.select("item", "*");

        int item_id = 0;
        string name = "";

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == "item_id")
                {
                    item_id = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "name")
                {
                    name = "" + reader.GetValue(i);
                }
            }
            items.Add(new Item(item_id, name));
            Debug.Log(items);
        }

    }
    public void onLoadPlayerfromDatabase() 
    {
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        IDataReader reader = adapter.select("players", "*");

        int id = 0;
        string username = "";
        int silver_coin = 0;
        int gold_coin = 0;
        int diamond = 0;



        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == "player_id")
                {
                    id = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "username")
                {
                    username = "" + reader.GetValue(i);
                }
                if (reader.GetName(i) == "silver")
                {
                    silver_coin = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "gold")
                {
                    gold_coin = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "diamond")
                {
                    diamond = Convert.ToInt32(reader.GetValue(i));
                }

            }
            player.Id = id;
            player.Username = username;
            player.Silver_coin = silver_coin;
            player.Gold_coin = gold_coin;
            player.Diamond = diamond;
            print(player.Silver_coin);
            // add gold
            // add diamon
        }



        adapter.disconnectDatabase();
    }

    public void addItemlootbox()// for add lootbot to inven and update player currency from shop
    {
        print("buy lootbox");
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        player.Diamond = player.Diamond - 300;
        adapter.insertItemfromShop(player.Id, 1, 1); //???
        adapter.updatePlayerDiamond(player.Diamond);

        adapter.disconnectDatabase();
    }
    public void addItemflashdrive()// for add flashdrive to inven and update player currency from shop
    {
        print("buy flashdrive");
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        player.Gold_coin = player.Gold_coin - 100;
        adapter.insertItemfromShop(player.Id, 2, 100);
        adapter.updatePlayerGold(player.Gold_coin);

        adapter.disconnectDatabase();

    }
    public void addPacksilver()//for update pack silver and update buy cost
    {
        print("buy silver");
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        player.Diamond = player.Diamond - 200;
        player.Silver_coin = player.Silver_coin + 200;
        adapter.updatePlayerSilver(player.Silver_coin);
        adapter.updatePlayerDiamond(player.Diamond);

        adapter.disconnectDatabase();
    }
    public void addPackgold()////for update pack silver and update buy cost
    {
        print("buy gold");
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        player.Diamond = player.Diamond - 200;
        player.Gold_coin = player.Gold_coin + 50;
        adapter.updatePlayerGold(player.Gold_coin);
        adapter.updatePlayerDiamond(player.Diamond);

        adapter.disconnectDatabase();
    }
    

    List<Shop> shops = new List<Shop>();
    public void onLoadShopfromDatabase() // for insert item to inven after buy 
    {
        SQliteAdapter adapter = new SQliteAdapter(DBFileName, DBFolder);
        IDataReader reader = adapter.select("shop", "*");

        int item_id = 0;
        string item_name = "";
        int silver_coin = 0;
        int gold_coin = 0;
        int diamond = 0;



        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == "item_id")
                {
                    item_id = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "item_name")
                {
                    item_name = "" + reader.GetValue(i);
                }
                if (reader.GetName(i) == "silver")
                {
                    silver_coin = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "gold")
                {
                    gold_coin = Convert.ToInt32(reader.GetValue(i));
                }
                if (reader.GetName(i) == "diamond")
                {
                    diamond = Convert.ToInt32(reader.GetValue(i));
                }
                shops.Add(new Shop(item_id, item_name, silver_coin, gold_coin, diamond));

            }
            
        }

        adapter.disconnectDatabase();
    }

    void Start()
    {
        onLoadfromDatabase();
        onLoadPlayerfromDatabase();
        onLoadShopfromDatabase();
        onLoadItemfromDatabase();
        myinventory.Add(1, (new Inventory(1, 1, 10)));
    }
    
}