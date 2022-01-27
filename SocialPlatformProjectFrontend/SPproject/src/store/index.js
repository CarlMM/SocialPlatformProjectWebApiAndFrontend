import { createStore } from "vuex"


const store = createStore({
   state:{
      Category:[{
         Id:1,
         Title:"Computer",
         Description:"Bla bla bla Computers",
      },
      {
         Id:2,
         Title:"Fishing",
         Description:"Bla bla bla Fishing"
      },
      {
         Id:3,
         Title:"Studies",
         Description:"Bla bla bla Studies"
      }],


      Thread:[{
         Id:1,
         Title:"Will computers take over the world?",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:1
         },
         {
         Id:2,
         Title:"Will computers NOT take over the world?",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:1
         },
         {
         Id:3,
         Title:"Will Mike ever NOT discuss things?",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:3
         },
         {
         Id:4,
         Title:"How good is Newton?",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:3
         },
         {
         Id:5,
         Title:"I swear look at this fish?",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:2
         },
         {
         Id:6,
         Title:"Do studies make you depressed?",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:3
         },
         {
         Id:7,
         Title:"STUDIES MAKE YOU RICH INVEST EVERYTHING",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:3
         },
         {
         Id:8,
         Title:"Super computer 30000",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:1
         },
         {
         Id:9,
         Title:"BIG FISH THREAD",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:2
         },
         {
         Id:10,
         Title:"WALLE - E MIKE EDITION",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:1
         },
         {
         Id:11,
         Title:"MIKES FISH IS AMAZING MICROTRANSISTIONS",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:2
         },
         {
         Id:12,
         Title:"Study more, earn less",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:3
         },
         {
         Id:13,
         Title:"Fish Fish Fish",
         Text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet sequi illo sint reprehenderit voluptate. Minus commodi non nesciunt nihil obcaecati provident quae, fugiat quidem. Facilis soluta inventore quidem id natus.",
         CategoryId:2
         },
         
      ]
        
   },
   mutations:{
       
   },
   actions:{
        
   }
})

export default store