using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        items.Add(new Item("Candle", 0, "It looks like the ones on the telporters"));
        items.Add(new Item("Diary", 1, "2019, march 3rd:\nI made a new spell!I call it ‘Door - b - gone!’: \nthe spell ingredients are: \nsomething shocking, \nsomething orcish and \nsomething hot.\nI bet I could bust open my front door with this.\n2019 march 5:\nDear diary: My jerk of an ex - wife came by today, \nshe had the nerve to \ntell me that I had to start paying child support, unbelievable!\nI am a grand wizard.I do NOT pay child support!\n2019 march 17:\nDear diary: Mr.Fireplace asked me for a raise today, claiming that \nthis whole tower would be an ice cube without him.\nI did the natural thing: I denied the raise and moved him to the basement.\n2019 April 5:\nDear diary: The ex - wife came back today, I didn’t pay child support \nso she told me that she was keeping my daughter.As a rebuttal \nI turned her into an orc, something to match her personality.\nShe was so mad she threw her wedding ring at me, i'll just put this in my safe.\n2019 April 9:\nDear diary: Just got back from the court trial, I’m paying child support now."));
        items.Add(new Item("Fire Ember", 2, "This is the ember Mr. Fireplace gave me, \nI can feel the heat, \nbut it doesn’t burn my hand."));
        items.Add(new Item("Glove", 3, "The glove belongs to the wizard, he has good taste"));
        items.Add(new Item("Lightning in a Jar", 4, "I made White Lightning!"));
        items.Add(new Item("Ring", 5, "Ring"));
        items.Add(new Item("Thor's Toothpick", 6, "One time I stuck this in a power outlet. \n I was out for 3 days."));
        items.Add(new Item("Staff", 7, "It's the wizard's long, powerful staff."));
    }
}
