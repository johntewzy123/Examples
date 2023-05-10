using System;
using System.Collections.Generic;
using System.Text;

namespace BasicOperation
{
    public class DataListItem
    {
        private String mData;
        private String mBarcodeType;
        private float mRSSI;
        private float mPhase;
        private float mFrequency;
        private int mCount;
        private bool mIsBarcode;

        public DataListItem()
        {
            mData = String.Empty;
            mBarcodeType = String.Empty;
            mIsBarcode = false;
            mRSSI = 0;
            mPhase = 0;
            mFrequency = 0;
            mCount = 1;
        }
        public DataListItem(String data, float rssi, float phase)
        {
            mData = data;
            mBarcodeType = String.Empty;
            mIsBarcode = false;
            mRSSI = rssi;
            mPhase = phase;
            mFrequency = 0;
            mCount = 1;
        }
        public DataListItem(String data, float rssi, float phase, float frequency)
        {
            mData = data;
            mBarcodeType = String.Empty;
            mIsBarcode = false;
            mRSSI = rssi;
            mPhase = phase;
            mFrequency = frequency;
            mCount = 1;
        }
        public DataListItem(String data, String barcodeType)
        {
            mData = data;
            mBarcodeType = barcodeType;
            mIsBarcode = true;
            mRSSI = 0;
            mPhase = 0;
            mFrequency = 0;
            mCount = 1;
        }

        public String Data { get { return mData; } }
        public String BarcodeType { get { return mBarcodeType; } }
        public bool IsBarcode { get { return mIsBarcode; } }
        public float RSSI { get { return mRSSI; } set { mRSSI = value; } }
        public float Phase { get { return mPhase; } set { mPhase = value; } }
        public float Frequency { get { return mFrequency; } set { mFrequency = value; } }
        public int Count { get { return mCount; } }

        public void Update()
        {
            mCount++;
        }
        public void Update(float rssi, float phase)
        {
            mRSSI = rssi;
            mPhase = phase;
            mCount++;
        }
        public void Update(float rssi, float phase, float frequency)
        {
            mRSSI = rssi;
            mPhase = phase;
            mFrequency = frequency;
            mCount++;
        }

        public override string ToString()
        {
            if (!mIsBarcode)
                return String.Format("[{0}] {1}, {2}, {3}", mData, mRSSI, mPhase, mCount);
            else
                return String.Format("[{0}] {1}, {2}", mData, mBarcodeType, mCount);
        }
    }
}
