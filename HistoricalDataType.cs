using MongoDB.Bson;

class HistoricalDataType
{
    public string HGDG_HS_KODU;
    public string HGDG_TARIH;
    public double HGDG_KAPANIS;
    public double HGDG_AOF;
    public double HGDG_MIN;
    public double HGDG_MAX;
    public double HGDG_HACIM;
    public string END_ENDEKS_KODU;
    public long END_TARIH;
    public int END_SEANS;
    public double END_DEGER;
    public string DD_DOVIZ_KODU;
    public string DD_DT_KODU;
    public long DD_TARIH;
    public double DD_DEGER;
    public double DOLAR_BAZLI_FIYAT;
    public double ENDEKS_BAZLI_FIYAT;
    public double DOLAR_HACIM;
    public double SERMAYE;
    public double HG_KAPANIS;
    public double HG_AOF;
    public double HG_MIN;
    public double HG_MAX;
    public double PD;
    public double PD_USD;
    public double HAO_PD;
    public double HAO_PD_USD;
    public double HG_HACIM;
    public double DOLAR_BAZLI_MIN;
    public double DOLAR_BAZLI_MAX;
    public double DOLAR_BAZLI_AOF;
}

class HistoricalDataTypeParameter{
    public string hisse { get; set; }
    public DateTime enddate { get; set; }
    public DateTime startdate { get; set; }
}

class HistoricalData{
    public ObjectId _id;
    public string Code { get; set; }
    public String Date { get; set; }
    public Decimal Amount { get; set; }
}