/*
Code automatically generated by asn1scc tool
*/

#include <string.h>
#include <math.h>
#include <limits.h>
#include "asn1crt.h"
#include "b_auto_tcs.h"


flag RGBCOLORS_enc_dec(const RGBCOLORS* pVal, int* pErrCode) 
{
    static RGBCOLORS decodedPDU;
    static byte encBuff[RGBCOLORS_REQUIRED_BYTES_FOR_ENCODING];
	BitStream bitStrm;
	flag ret;

  	BitStream_Init(&bitStrm, encBuff, RGBCOLORS_REQUIRED_BYTES_FOR_ENCODING);
    // Encode value
    ret = RGBCOLORS_Encode(pVal, &bitStrm, pErrCode, TRUE);
    *pErrCode = ret ? 0 : 1;
    if (ret) {
        BitStream_AttachBuffer(&bitStrm, encBuff, RGBCOLORS_REQUIRED_BYTES_FOR_ENCODING);
        // Decode value
        ret = RGBCOLORS_Decode(&decodedPDU, &bitStrm, pErrCode);
        *pErrCode = ret ? 0 : 2;
        if (ret) {
            // validate decoded data
            ret = RGBCOLORS_IsConstraintValid(&decodedPDU, pErrCode);
            *pErrCode = ret ? 0 : 3;
            if (ret) {
                ret = RGBCOLORS_Equal(pVal, &decodedPDU);
                *pErrCode = ret ? 0 : 4;

            }
        }
    }
    return ret;
};
flag OTHERCOLORS_enc_dec(const OTHERCOLORS* pVal, int* pErrCode) 
{
    static OTHERCOLORS decodedPDU;
    static byte encBuff[OTHERCOLORS_REQUIRED_BYTES_FOR_ENCODING];
	BitStream bitStrm;
	flag ret;

  	BitStream_Init(&bitStrm, encBuff, OTHERCOLORS_REQUIRED_BYTES_FOR_ENCODING);
    // Encode value
    ret = OTHERCOLORS_Encode(pVal, &bitStrm, pErrCode, TRUE);
    *pErrCode = ret ? 0 : 1;
    if (ret) {
        BitStream_AttachBuffer(&bitStrm, encBuff, OTHERCOLORS_REQUIRED_BYTES_FOR_ENCODING);
        // Decode value
        ret = OTHERCOLORS_Decode(&decodedPDU, &bitStrm, pErrCode);
        *pErrCode = ret ? 0 : 2;
        if (ret) {
            // validate decoded data
            ret = OTHERCOLORS_IsConstraintValid(&decodedPDU, pErrCode);
            *pErrCode = ret ? 0 : 3;
            if (ret) {
                ret = OTHERCOLORS_Equal(pVal, &decodedPDU);
                *pErrCode = ret ? 0 : 4;

            }
        }
    }
    return ret;
};
flag CH2_left_enc_dec(const CH2_left* pVal, int* pErrCode) 
{
    static CH2_left decodedPDU;
    static byte encBuff[CH2_left_REQUIRED_BYTES_FOR_ENCODING];
	BitStream bitStrm;
	flag ret;

  	BitStream_Init(&bitStrm, encBuff, CH2_left_REQUIRED_BYTES_FOR_ENCODING);
    // Encode value
    ret = CH2_left_Encode(pVal, &bitStrm, pErrCode, TRUE);
    *pErrCode = ret ? 0 : 1;
    if (ret) {
        BitStream_AttachBuffer(&bitStrm, encBuff, CH2_left_REQUIRED_BYTES_FOR_ENCODING);
        // Decode value
        ret = CH2_left_Decode(&decodedPDU, &bitStrm, pErrCode);
        *pErrCode = ret ? 0 : 2;
        if (ret) {
            // validate decoded data
            ret = CH2_left_IsConstraintValid(&decodedPDU, pErrCode);
            *pErrCode = ret ? 0 : 3;
            if (ret) {
                ret = CH2_left_Equal(pVal, &decodedPDU);
                *pErrCode = ret ? 0 : 4;

            }
        }
    }
    return ret;
};
flag CH2_enc_dec(const CH2* pVal, int* pErrCode) 
{
    static CH2 decodedPDU;
    static byte encBuff[CH2_REQUIRED_BYTES_FOR_ENCODING];
	BitStream bitStrm;
	flag ret;

  	BitStream_Init(&bitStrm, encBuff, CH2_REQUIRED_BYTES_FOR_ENCODING);
    // Encode value
    ret = CH2_Encode(pVal, &bitStrm, pErrCode, TRUE);
    *pErrCode = ret ? 0 : 1;
    if (ret) {
        BitStream_AttachBuffer(&bitStrm, encBuff, CH2_REQUIRED_BYTES_FOR_ENCODING);
        // Decode value
        ret = CH2_Decode(&decodedPDU, &bitStrm, pErrCode);
        *pErrCode = ret ? 0 : 2;
        if (ret) {
            // validate decoded data
            ret = CH2_IsConstraintValid(&decodedPDU, pErrCode);
            *pErrCode = ret ? 0 : 3;
            if (ret) {
                ret = CH2_Equal(pVal, &decodedPDU);
                *pErrCode = ret ? 0 : 4;

            }
        }
    }
    return ret;
};
flag CH1_left_enc_dec(const CH1_left* pVal, int* pErrCode) 
{
    static CH1_left decodedPDU;
    static byte encBuff[CH1_left_REQUIRED_BYTES_FOR_ENCODING];
	BitStream bitStrm;
	flag ret;

  	BitStream_Init(&bitStrm, encBuff, CH1_left_REQUIRED_BYTES_FOR_ENCODING);
    // Encode value
    ret = CH1_left_Encode(pVal, &bitStrm, pErrCode, TRUE);
    *pErrCode = ret ? 0 : 1;
    if (ret) {
        BitStream_AttachBuffer(&bitStrm, encBuff, CH1_left_REQUIRED_BYTES_FOR_ENCODING);
        // Decode value
        ret = CH1_left_Decode(&decodedPDU, &bitStrm, pErrCode);
        *pErrCode = ret ? 0 : 2;
        if (ret) {
            // validate decoded data
            ret = CH1_left_IsConstraintValid(&decodedPDU, pErrCode);
            *pErrCode = ret ? 0 : 3;
            if (ret) {
                ret = CH1_left_Equal(pVal, &decodedPDU);
                *pErrCode = ret ? 0 : 4;

            }
        }
    }
    return ret;
};
flag CH1_enc_dec(const CH1* pVal, int* pErrCode) 
{
    static CH1 decodedPDU;
    static byte encBuff[CH1_REQUIRED_BYTES_FOR_ENCODING];
	BitStream bitStrm;
	flag ret;

  	BitStream_Init(&bitStrm, encBuff, CH1_REQUIRED_BYTES_FOR_ENCODING);
    // Encode value
    ret = CH1_Encode(pVal, &bitStrm, pErrCode, TRUE);
    *pErrCode = ret ? 0 : 1;
    if (ret) {
        BitStream_AttachBuffer(&bitStrm, encBuff, CH1_REQUIRED_BYTES_FOR_ENCODING);
        // Decode value
        ret = CH1_Decode(&decodedPDU, &bitStrm, pErrCode);
        *pErrCode = ret ? 0 : 2;
        if (ret) {
            // validate decoded data
            ret = CH1_IsConstraintValid(&decodedPDU, pErrCode);
            *pErrCode = ret ? 0 : 3;
            if (ret) {
                ret = CH1_Equal(pVal, &decodedPDU);
                *pErrCode = ret ? 0 : 4;

            }
        }
    }
    return ret;
};
