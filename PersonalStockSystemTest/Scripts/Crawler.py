#!/usr/bin/env python
# coding: utf-8

# In[1]:


from bs4 import BeautifulSoup
import requests
import datetime
import pandas as pd
import json
import sys

target_Stock = sys.argv[1] #股票代碼
start_date = "2023/06/07" #起始日期


current_date = datetime.datetime.now()
current_date = str(current_date.year)+"/"+str(current_date.month)+"/"+str(current_date.day)

headers = {"User-Agent":"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36"}
url = "https://www.cnyes.com/twstock/ps_historyprice.aspx?code=" + target_Stock

form_data = {
    "pageTypeHidden": 1,
    "code": target_Stock,
    "ctl00$ContentPlaceHolder1$startText": start_date,
    "ctl00$ContentPlaceHolder1$endText": current_date,
    "ctl00$ContentPlaceHolder1$submitBut": "查詢"}

session = requests.Session()
resp = session.post(url, headers=headers, data = form_data)
resp.encoding = "utf-8"
soup = BeautifulSoup(resp.text, "lxml")
a = soup.find_all("td")
result = pd.DataFrame(index=range(int(len(a)/10)), columns=["日期","開盤","最高","最低","收盤","成交量","成交金額"])

for i in range(len(a)):
    if (i % 10 == 0) and (a[i].attrs['class'][0] == "cr"):
        result.iloc[int(i/10),0] = a[i+0].text
        result.iloc[int(i/10),1] = float(a[i+1].text)
        result.iloc[int(i/10),2] = float(a[i+2].text)
        result.iloc[int(i/10),3] = float(a[i+3].text) 
        result.iloc[int(i/10),4] = float(a[i+4].text)
        result.iloc[int(i/10),5] = float("".join(a[i+7].text.split(",")))
        result.iloc[int(i/10),6] = float("".join(a[i+8].text.split(",")))
       
result = result.dropna()
result_json = result.to_json(orient="records")

print(json.loads(result_json))
    

# In[ ]:




